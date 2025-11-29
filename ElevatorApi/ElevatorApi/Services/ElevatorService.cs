using ElevatorApi.Models;
using ElevatorApi.Services.Interfaces;

namespace ElevatorApi.Services
{
    public class ElevatorService : IElevatorService
    {
        /// <summary>
        /// Call elevator to a floor you're on
        /// </summary>
        /// <param name="number">Floor you're on</param>
        /// <param name="up">Request is for Up (true/false)</param>
        /// <returns>Elevator status</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Elevator CallToFloor(int number, bool up)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "floor must be a positive integer");
            }
            var elevator = new Elevator();
            var highestFloor = elevator.Floors.Max(x => x.Number);
            var lowestFloor = elevator.Floors.Min(x => x.Number);
            if (number > highestFloor)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"number cannot be greater than the number of floors: {highestFloor}");
            }
            if (number == highestFloor && up)
            {
                throw new ArgumentException("Cannot go up from the highest floor", nameof(up));
            }
            if (number == lowestFloor && !up)
            {
                throw new ArgumentException("Cannot go down from the lowest floor", nameof(up));
            }

            //Mock some passenger requests
            elevator.AddPassengerRequest(6);
            elevator.AddPassengerRequest(13);
            elevator.AddPassengerRequest(14);

            elevator.AddCallRequest(number, up);

            return elevator;
        }

        /// <summary>
        /// Get the next floor of the elevator given its current floor
        /// </summary>
        /// <param name="currentFloor">The elevator's current floor</param>
        /// <returns>The next floor</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
            elevator.AddCallRequest(20, false);

            return elevator.NextFloor;
        }

        /// <summary>
        /// Get all passenger requests
        /// </summary>
        /// <returns>List of passenger requests</returns>
        public IEnumerable<FloorRequest> GetPassengerRequests()
        {
            var elevator = new Elevator();

            //Mock some passenger requests
            elevator.AddPassengerRequest(3);
            elevator.AddPassengerRequest(12);
            elevator.AddPassengerRequest(17);
            elevator.AddCallRequest(20, false);
            elevator.AddCallRequest(5, true);

            return elevator.FloorRequests.Where(req => req.RequestType == FloorRequestType.Passenger).ToList();
        }

        /// <summary>
        /// Request a floor from inside the elevator
        /// </summary>
        /// <param name="number">The number requested</param>
        /// <returns>The state of the elevator</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
