using ElevatorApi.Models;
using ElevatorApi.Services.Interfaces;

namespace ElevatorApi.Services
{
    public class ElevatorService : IElevatorService
    {
        public Elevator CallToFloor(int number)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "floor must be a positive integer");
            }
            var elevator = new Elevator();
            var highestFloor = elevator.Floors.Max(x => x.Number);
            if (number > highestFloor)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"number cannot be greater than the number of floors: {highestFloor}");
            }

            //Mock some passenger requests
            elevator.AddPassengerRequest(6);
            elevator.AddPassengerRequest(13);
            elevator.AddPassengerRequest(14);

            elevator.AddCallRequest(number);

            return elevator;
        }

        public Floor GetNextFloor(int currentFloor)
        {
            if (currentFloor < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(currentFloor), "currentFloor must be a positive integer");
            }

            var elevator = new Elevator();
            var highestFloor = elevator.Floors.Max(x => x.Number);
            if (currentFloor > highestFloor)
            {
                throw new ArgumentOutOfRangeException(nameof(currentFloor), $"currentFloor cannot be greater than the number of floors: {highestFloor}");
            }
            else
            {
                elevator.CurrentFloor = new Floor(currentFloor);
            }

            //Mock some requests
            elevator.AddPassengerRequest(2);
            elevator.AddPassengerRequest(9);
            elevator.AddPassengerRequest(14);
            elevator.AddCallRequest(20);

            return elevator.NextFloor;
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
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "floor must be a positive integer");
            }
            var elevator = new Elevator();
            var highestFloor = elevator.Floors.Max(x => x.Number);
            if (number > highestFloor)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"number cannot be greater than the number of floors: {highestFloor}");
            }

            //Mock some passenger requests
            elevator.AddPassengerRequest(7);
            elevator.AddPassengerRequest(10);
            elevator.AddPassengerRequest(4);

            elevator.AddPassengerRequest(number);

            return elevator;
        }
    }
}
