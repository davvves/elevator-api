namespace ElevatorApi.Models
{
    public class FloorRequest
    {
        public int Floor { get; set; }
        public FloorRequestType RequestType { get; set; }
    }

    public enum FloorRequestType
    {
        Passenger,
        Call
    }
}
