using ElevatorApi.Models;
using ElevatorApi.Services.Interface;
using ElevatorApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElevatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorService elevatorService;
        private readonly IHttpResponseWrapper httpResponseWrapper;

        public ElevatorController(IElevatorService elevatorService, IHttpResponseWrapper httpResponseWrapper)
        {
            this.elevatorService = elevatorService;
            this.httpResponseWrapper = httpResponseWrapper;
        }

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

        [HttpPost]
        [Route("CallToFloor")]
        public ApiResponse<Elevator> CallToFloor([FromBody] int number)
        {
            try
            {
                var elevator = elevatorService.CallToFloor(number);
                return new ApiResponse<Elevator>(elevator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateHttpStatusCode(ex);
                return new ApiResponse<Elevator>(null, ex.Message);
            }
        }

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

        private void UpdateHttpStatusCode(Exception ex)
        {
            if (ex is ArgumentNullException || ex is ArgumentException)
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
