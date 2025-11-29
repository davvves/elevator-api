using System.Text.Json.Serialization;

namespace ElevatorApi.Models
{
    /// <summary>
    /// The class representing the elevator's current state
    /// </summary>
    public class Elevator
    {
        public Elevator()
        {
            //For the purposes of this mock data the direction always starts as up
            this.Direction = Direction.Up;

            this.CurrentFloor = new Floor(1);
            this.Floors = new List<Floor>();
            for (int i = 1; i <= 20; i++)
            {
                this.Floors.Add(new Floor(i));
            }
            this.FloorRequests = [];
        }

        /// <summary>
        /// The current floor of the elevator
        /// </summary>
        public Floor CurrentFloor { get; set; }

        /// <summary>
        /// All the available floors for the elevator
        /// </summary>
        public List<Floor> Floors { get; set; }

        /// <summary>
        /// All current requests the elevator has received
        /// </summary>
        public List<FloorRequest> FloorRequests { get; set; }

        /// <summary>
        /// The current direction of the elevator
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Direction Direction { get; set; }

        /// <summary>
        /// Request a floor as a current passenger of the elevator (i.e. from the inside panel)
        /// </summary>
        /// <param name="floor">The floor number requested</param>
        public void AddPassengerRequest(int floor)
        {
            if (!FloorRequests.Any(req => req.Floor == floor))
            {
                FloorRequests.Add(new FloorRequest(floor, FloorRequestType.Passenger));
            }
        }

        /// <summary>
        /// Request that the elevator come to your current floor
        /// </summary>
        /// <param name="floor">The floor number requested</param>
        /// <param name="up">Whether the request is for Up direction</param>
        public void AddCallRequest(int floor, bool up)
        {
            if (!FloorRequests.Any(req => req.Floor == floor))
            {
                FloorRequests.Add(new FloorRequest(floor, FloorRequestType.Call, up ? Direction.Up : Direction.Down));
            }
        }

        /// <summary>
        /// The next floor the elevator will stop at
        /// </summary>
        public Floor NextFloor
        {
            get
            {
                //If we're already at the requested floor, remove that request and go to the next floor
                FloorRequests = FloorRequests.Where(x => x.Floor != CurrentFloor.Number).ToList();

                var sortedRequests = FloorRequests.OrderBy(x => x.Floor).ToList();
                if (sortedRequests.Count == 0)
                {
                    return CurrentFloor;
                }
                if (Direction == Direction.Up)
                {
                    var nextHigherFloor = sortedRequests.FirstOrDefault(x => x.Floor > CurrentFloor.Number && x.Direction != Direction.Down);
                    if (nextHigherFloor != null)
                    {
                        return new Floor(nextHigherFloor.Floor);
                    }
                    else
                    {
                        Direction = Direction.Down;
                        var nextLowerFloor = sortedRequests.LastOrDefault(x => x.Floor < CurrentFloor.Number && x.Direction != Direction.Up);
                        if (nextLowerFloor != null)
                        {
                            return new Floor(nextLowerFloor.Floor);
                        }
                    }
                }
                else if (Direction == Direction.Down)
                {
                    var nextLowerFloor = sortedRequests.LastOrDefault(x => x.Floor < CurrentFloor.Number && x.Direction != Direction.Up);
                    if (nextLowerFloor != null)
                    {
                        return new Floor(nextLowerFloor.Floor);
                    }
                    else
                    {
                        Direction = Direction.Up;
                        var nextHigherFloor = sortedRequests.FirstOrDefault(x => x.Floor > CurrentFloor.Number && x.Direction != Direction.Down);
                        if (nextHigherFloor != null)
                        {
                            return new Floor(nextHigherFloor.Floor);
                        }
                    }
                }
                return CurrentFloor;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down
    }
}