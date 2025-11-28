namespace ElevatorApi.Models
{
    public class ApiResponse<T>(T? returnObject, string message = "")
    {
        /// <summary>
        /// The object passed back with a successful response
        /// </summary>
        public T? Response { get; set; } = returnObject;

        /// <summary>
        /// Any error message
        /// </summary>
        public string Message { get; set; } = message;
    }
}
