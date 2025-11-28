using System.Text.Json.Serialization;

namespace ElevatorApi.Models
{
    public class Elevator
    {
        public Elevator()
        {
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
        public Direction Direction
        {
            get
            {
                return Direction.Up; //TODO: Implement in the next floor request story
            }
        }

        public void AddPassengerRequest(int floor)
        {
            FloorRequests.Add(new FloorRequest(floor, FloorRequestType.Passenger));
        }
        public void AddCallRequest(int floor)
        {
            FloorRequests.Add(new FloorRequest(floor, FloorRequestType.Call));
        }

        public Floor NextFloor
        {
            get
            {
                return new Floor(1); //TODO: Implement in the next floor request story
            }
        }
    }

    public enum Direction
    {
        Up,
        Down
    }
}