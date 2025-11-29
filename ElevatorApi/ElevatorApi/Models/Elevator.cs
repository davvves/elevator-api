using System.Text.Json.Serialization;

namespace ElevatorApi.Models
{
    public class Elevator
    {
        public Elevator()
        {
            this.Direction = Direction.Up;
            this.CurrentFloor = new Floor(1);
            this.Floors = new List<Floor>();
            for (int i = 1; i <= 20; i++)
            {
                this.Floors.Add(new Floor(i));
            }
            this.FloorRequests = new List<FloorRequest>();
        }

        public Floor CurrentFloor { get; set; }

        public List<Floor> Floors { get; set; }

        public List<FloorRequest> FloorRequests { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Direction Direction { get; set; }

        public void AddPassengerRequest(int floor)
        {
            if (!FloorRequests.Any(req => req.Floor == floor))
            {
                FloorRequests.Add(new FloorRequest(floor, FloorRequestType.Passenger));
            }
        }
        public void AddCallRequest(int floor)
        {
            if (!FloorRequests.Any(req => req.Floor == floor))
            {
                FloorRequests.Add(new FloorRequest(floor, FloorRequestType.Call));
            }
        }

        public Floor NextFloor
        {
            get
            {
                //If we're already at the requested floor, remove that request and go to the next floor
                FloorRequests = FloorRequests.Where(x => x.Floor != CurrentFloor.Number).ToList();

                var sortedRequests = FloorRequests.OrderBy(x => x.Floor).ToList();
                if (!sortedRequests.Any())
                {
                    return CurrentFloor;
                }
                if (Direction == Direction.Up)
                {
                    var nextHigherFloor = sortedRequests.FirstOrDefault(x => x.Floor > CurrentFloor.Number);
                    if (nextHigherFloor != null)
                    {
                        return new Floor(nextHigherFloor.Floor);
                    }
                    else
                    {
                        Direction = Direction.Down;
                        var nextLowerFloor = sortedRequests.LastOrDefault(x => x.Floor < CurrentFloor.Number);
                        if (nextLowerFloor != null)
                        {
                            return new Floor(nextLowerFloor.Floor);
                        }
                    }
                }
                else if (Direction == Direction.Down)
                {
                    var nextLowerFloor = sortedRequests.LastOrDefault(x => x.Floor < CurrentFloor.Number);
                    if (nextLowerFloor != null)
                    {
                        return new Floor(nextLowerFloor.Floor);
                    }
                    else
                    {
                        Direction = Direction.Up;
                        var nextHigherFloor = sortedRequests.FirstOrDefault(x => x.Floor > CurrentFloor.Number);
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