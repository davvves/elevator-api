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
            this.Direction = Direction.Up;
        }

        public List<Floor> Floors { get; set; }
        public List<FloorRequest> FloorRequests { get; set; }
        public Direction Direction { get; set; }
    }

    public enum Direction
    {
        Up,
        Down
    }
}