using ElevatorApi.Models;
using ElevatorApi.Services.Interface;
using ElevatorApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElevatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController(IElevatorService elevatorService, IHttpResponseWrapper httpResponseWrapper) : ControllerBase
    {
        /// <summary>
        /// Get all passenger requests from inside the elevator
        /// </summary>
        /// <returns>all passenger requests from inside the elevator, or an error message if generated</returns>
        [HttpGet("GetPassengerRequests")]
        public ApiResponse<IEnumerable<FloorRequest>> GetPassengerRequests()
        {
            try
            {
                var requests = elevatorService.GetPassengerRequests();
                return new ApiResponse<IEnumerable<FloorRequest>>(requests);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateHttpStatusCode(ex);
                return new ApiResponse<IEnumerable<FloorRequest>>(null, ex.Message);
            }
        }

        /// <summary>
        /// Call the elevator to a floor from that floor
        /// </summary>
        /// <param name="request">A request object containing the floor number and whether the request is for Up (true/false)</param>
        /// <returns>The state of the elevator, or an error message if generated</returns>
        [HttpPost]
        [Route("CallToFloor")]
        public ApiResponse<Elevator> CallToFloor([FromBody] CallToFloorRequest request)
        {
            try
            {
                var elevator = elevatorService.CallToFloor(request.Number, request.Up);
                return new ApiResponse<Elevator>(elevator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateHttpStatusCode(ex);
                return new ApiResponse<Elevator>(null, ex.Message);
            }
        }

        /// <summary>
        /// Request a floor from inside the elevator as a passenger
        /// </summary>
        /// <param name="number">The floor number requested</param>
        /// <returns>The state of the elevator, or an error message if generated</returns>
        [HttpPost]
        [Route("RequestFloor")]
        public ApiResponse<Elevator> RequestFloor([FromBody] int number)
        {
            try
            {
                var elevator = elevatorService.RequestFloor(number);
                return new ApiResponse<Elevator>(elevator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateHttpStatusCode(ex);
                return new ApiResponse<Elevator>(null, ex.Message);
            }
        }

        /// <summary>
        /// Get the next floor of the elevator
        /// </summary>
        /// <param name="currentFloor">The current floor of the elevator</param>
        /// <returns>The next floor of the elevator, or an error message if generated</returns>
        [HttpGet("GetNextFloor")]
        public ApiResponse<Floor> GetNextFloor(int currentFloor)
        {
            try
            {
                var floor = elevatorService.GetNextFloor(currentFloor);
                return new ApiResponse<Floor>(floor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateHttpStatusCode(ex);
                return new ApiResponse<Floor>(null, ex.Message);
            }
        }

        private void UpdateHttpStatusCode(Exception ex)
        {
            if (ex is ArgumentNullException || ex is ArgumentException || ex is ArgumentOutOfRangeException)
            {
                httpResponseWrapper.GetCurrentResponse()?.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                httpResponseWrapper.GetCurrentResponse()?.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
