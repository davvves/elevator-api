using System.Text.Json.Serialization;

namespace ElevatorApi.Models
{

    public class FloorRequest
    {
        public FloorRequest(int floor, FloorRequestType floorRequestType)
        {
            this.Floor = floor;
            this.RequestType = floorRequestType;
        }

        public int Floor { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FloorRequestType RequestType { get; set; }
    }

    public enum FloorRequestType
    {
        Passenger,
        Call
    }
}
