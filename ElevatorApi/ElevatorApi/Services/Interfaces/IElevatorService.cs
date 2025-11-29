using ElevatorApi.Models;

namespace ElevatorApi.Services.Interfaces
{
    public interface IElevatorService
    {
        IEnumerable<FloorRequest> GetPassengerRequests();

        Elevator CallToFloor(int number, bool up);

        Elevator RequestFloor(int number);

        Floor GetNextFloor(int currentFloor);
    }
}
