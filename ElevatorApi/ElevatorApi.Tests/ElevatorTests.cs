using ElevatorApi.Models;

namespace ElevatorApi.Tests
{
    [TestClass]
    public sealed class ElevatorTests
    {
        private Elevator elevator;

        [TestInitialize]
        public void Initialize()
        {
            this.elevator = new Elevator();
        }

        [TestMethod]
        public void AddPassengerRequest_Does_Not_Add_Duplicates()
        {
            elevator.AddPassengerRequest(5);
            elevator.AddPassengerRequest(5);
            elevator.AddPassengerRequest(5);
            Assert.AreEqual(1, elevator.FloorRequests.Count(req => req.RequestType == FloorRequestType.Passenger));
        }

        [TestMethod]
        public void AddCallRequest_Does_Not_Add_Duplicates()
        {
            elevator.AddCallRequest(5, true);
            elevator.AddCallRequest(5, false);
            elevator.AddCallRequest(5, true);
            Assert.AreEqual(1, elevator.FloorRequests.Count(req => req.RequestType == FloorRequestType.Call));
        }

        [TestMethod]
        public void GetNextFloor_Changes_Direction_To_Down_When_Direction_Is_Up_And_Next_Floor_Is_Below_Current_Floor()
        {
            elevator.CurrentFloor = new Floor(20);
            elevator.AddPassengerRequest(5);
            var nextFloor = elevator.NextFloor;
            Assert.AreEqual(Direction.Down, elevator.Direction);
        }

        [TestMethod]
        public void GetNextFloor_Changes_Direction_To_Up_When_Direction_Is_Down_And_Next_Floor_Is_Above_Current_Floor()
        {
            elevator.CurrentFloor = new Floor(5);
            elevator.AddPassengerRequest(20);
            elevator.Direction = Direction.Down;
            var nextFloor = elevator.NextFloor;
            Assert.AreEqual(Direction.Up, elevator.Direction);
        }

        [TestMethod]
        public void GetNextFloor_Skips_Request_If_Direction_Is_Opposite_Current_Direction()
        {
            elevator.CurrentFloor = new Floor(5);
            elevator.AddCallRequest(10, false);
            elevator.AddPassengerRequest(20);
            var nextFloor = elevator.NextFloor;
            Assert.AreEqual(20, nextFloor.Number);
        }
    }
}
