using System.Text.Json.Serialization;

namespace ElevatorApi.Models
{

    public class FloorRequest
    {
        /// <summary>
        /// A request for the elevator to come to a certain floor
        /// </summary>
        /// <param name="floor">The floor requested</param>
        /// <param name="floorRequestType">The type of the request</param>
        /// <param name="direction">The direction of the request, in case of a call request</param>
        public FloorRequest(int floor, FloorRequestType floorRequestType, Direction? direction = null)
        {
            this.Floor = floor;
            this.RequestType = floorRequestType;
            Direction = direction;
        }

        /// <summary>
        /// The floor requested
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// The type of the request
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FloorRequestType RequestType { get; set; }

        /// <summary>
        /// The direction of the request, in case of a call request
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Direction? Direction { get; set; }
    }

    public enum FloorRequestType
    {
        Passenger,
        Call
    }
}
