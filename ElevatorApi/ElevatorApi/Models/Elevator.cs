using System.Text.Json.Serialization;

namespace ElevatorApi.Models
{
    public class Elevator
    {
        public Elevator()
        {
            this.Floors = new List<Floor>();
            for (int i = 1; i <= 20; i++)
            {
                this.Floors.Add(new Floor(i));
            }
            this.FloorRequests = new List<FloorRequest>();
            this.Direction = Direction.Up;
        }

        public List<Floor> Floors { get; set; }
        public List<FloorRequest> FloorRequests { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Direction Direction { get; set; }

        public void AddPassengerRequest(int floor)
        {
            FloorRequests.Add(new FloorRequest(floor, FloorRequestType.Passenger));
        }
    }

    public enum Direction
    {
        Up,
        Down
    }
}