using ElevatorApi.Models;
using ElevatorApi.Services.Interfaces;

namespace ElevatorApi.Services
{
    public class ElevatorService : IElevatorService
    {
        public Elevator CallToFloor(int number)
        {
            var elevator = new Elevator();

            //Mock some passenger requests
            elevator.AddPassengerRequest(6);
            elevator.AddPassengerRequest(13);
            elevator.AddPassengerRequest(14);

            elevator.AddCallRequest(number);

            return elevator;
        }

        public IEnumerable<FloorRequest> GetPassengerRequests()
        {
            var elevator = new Elevator();

            //Mock some passenger requests
            elevator.AddPassengerRequest(3);
            elevator.AddPassengerRequest(12);
            elevator.AddPassengerRequest(17);

            return elevator.FloorRequests.Where(req => req.RequestType == FloorRequestType.Passenger).ToList();
        }

        public Elevator RequestFloor(int number)
        {
            var elevator = new Elevator();

            //Mock some passenger requests
            elevator.AddPassengerRequest(7);
            elevator.AddPassengerRequest(10);
            elevator.AddPassengerRequest(4);

            elevator.AddPassengerRequest(number);

            return elevator;
        }
    }
}
