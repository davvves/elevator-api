using ElevatorApi.Models;
using ElevatorApi.Services;

namespace ElevatorApi.Tests
{
    [TestClass]
    public sealed class ElevatorServiceTests
    {
        private ElevatorService elevatorService;

        [TestInitialize]
        public void Initialize()
        {
            elevatorService = new ElevatorService();
        }

        [TestMethod]
        public void CallToFloor_Throws_Exception_If_Number_Is_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => elevatorService.CallToFloor(-1, true));
        }

        [TestMethod]
        public void CallToFloor_Throws_Exception_If_Number_Is_Too_High()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => elevatorService.CallToFloor(21, false));
        }

        [TestMethod]
        public void CallToFloor_Throws_Exception_If_Going_Up_From_Top_Floor()
        {
            Assert.Throws<ArgumentException>(() => elevatorService.CallToFloor(20, true));
        }


        [TestMethod]
        public void CallToFloor_Throws_Exception_If_Going_Down_From_Bottom_Floor()
        {
            Assert.Throws<ArgumentException>(() => elevatorService.CallToFloor(20, true));
        }

        [TestMethod]
        public void CallToFloor_Adds_Request_To_Requests()
        {
            var elevator = elevatorService.CallToFloor(5, true);
            Assert.IsTrue(elevator.FloorRequests.Where(req => req.RequestType == FloorRequestType.Call && req.Floor == 5).Any());
        }

        [TestMethod]
        public void GetNextFloor_Throws_Exception_If_Number_Is_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => elevatorService.GetNextFloor(-1));
        }

        [TestMethod]
        public void GetNextFloor_Throws_Exception_If_Number_Is_Too_High()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => elevatorService.GetNextFloor(21));
        }

        [TestMethod]
        public void GetNextFloor_Returns_Lower_Floor_If_Current_Floor_Is_Highest()
        {
            var floor = elevatorService.GetNextFloor(20);
            Assert.IsLessThan(20, floor.Number);
        }

        [TestMethod]
        public void GetNextFloor_Returns_Higher_Floor_If_Current_Floor_Is_Lowest()
        {
            var floor = elevatorService.GetNextFloor(1);
            Assert.IsGreaterThan(1, floor.Number);
        }

        [TestMethod]
        public void GetNextFloor_Returns_Higher_Floor_If_Current_Floor_Is_In_Middle()
        {
            var floor = elevatorService.GetNextFloor(5);
            Assert.IsGreaterThan(5, floor.Number);
        }

        [TestMethod]
        public void GetPassengerRequests_Returns_Only_Passenger_Requests()
        {
            var requests = elevatorService.GetPassengerRequests();
            Assert.IsFalse(requests.Any(req => req.RequestType == FloorRequestType.Call));
        }

        [TestMethod]
        public void RequestFloor_Throws_Exception_If_Number_Is_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => elevatorService.RequestFloor(-1));
        }

        [TestMethod]
        public void RequestFloor_Throws_Exception_If_Number_Is_Too_High()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => elevatorService.RequestFloor(21));
        }

        [TestMethod]
        public void RequestFloor_Adds_Request_To_Requests()
        {
            var elevator = elevatorService.RequestFloor(5);
            Assert.IsTrue(elevator.FloorRequests.Where(req => req.RequestType == FloorRequestType.Passenger && req.Floor == 5).Any());
        }
    }
}
