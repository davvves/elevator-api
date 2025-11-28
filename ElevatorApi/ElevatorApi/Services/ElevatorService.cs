using ElevatorApi.Models;
using ElevatorApi.Services.Interfaces;

namespace ElevatorApi.Services
{
    public class ElevatorService : IElevatorService
    {
        public IEnumerable<FloorRequest> GetPassengerRequests()
        {
            var elevator = new Elevator();

            //Mock some passenger requests
            elevator.AddPassengerRequest(3);
            elevator.AddPassengerRequest(12);
            elevator.AddPassengerRequest(17);

            return elevator.FloorRequests.Where(req => req.RequestType == FloorRequestType.Passenger).ToList();
        }

    }
}
