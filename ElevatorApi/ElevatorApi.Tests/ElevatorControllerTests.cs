using ElevatorApi.Controllers;
using ElevatorApi.Models;
using ElevatorApi.Services.Interface;
using ElevatorApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ElevatorApi.Tests
{
    [TestClass]
    public sealed class ElevatorControllerTests
    {
        private ElevatorController controller;
        private Mock<IElevatorService> elevatorServiceMock;
        private Mock<IHttpResponseWrapper> httpResponseWrapperMock;

        [TestInitialize]
        public void Initialize()
        {
            elevatorServiceMock = new Mock<IElevatorService>();
            httpResponseWrapperMock = new Mock<IHttpResponseWrapper>();
            httpResponseWrapperMock.Setup(x => x.GetCurrentResponse()).Returns(new Mock<HttpResponse>().Object);
            controller = new ElevatorController(elevatorServiceMock.Object, httpResponseWrapperMock.Object);
        }

        [TestMethod]
        public void GetPassengerRequests_Returns_Object_From_Service()
        {
            var returnValue = new List<FloorRequest>();
            elevatorServiceMock.Setup(x => x.GetPassengerRequests()).Returns(returnValue);
            Assert.AreEqual(returnValue, controller.GetPassengerRequests().Response);
        }

        [TestMethod]
        public void GetPassengerRequests_Returns_Message_If_Exception_Is_Thrown()
        {
            elevatorServiceMock.Setup(x => x.GetPassengerRequests()).Throws<ArgumentOutOfRangeException>();
            Assert.IsGreaterThan(0, controller.GetPassengerRequests().Message.Length);
        }

        [TestMethod]
        public void CallToFloor_Returns_Object_From_Service()
        {
            var returnValue = new Elevator();
            elevatorServiceMock.Setup(x => x.CallToFloor(5)).Returns(returnValue);
            Assert.AreEqual(returnValue, controller.CallToFloor(5).Response);
        }

        [TestMethod]
        public void CallToFloor_Returns_Message_If_Exception_Is_Thrown()
        {
            elevatorServiceMock.Setup(x => x.CallToFloor(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
            Assert.IsGreaterThan(0, controller.CallToFloor(-1).Message.Length);
        }

        [TestMethod]
        public void RequestFloor_Returns_Object_From_Service()
        {
            var returnValue = new Elevator();
            elevatorServiceMock.Setup(x => x.RequestFloor(5)).Returns(returnValue);
            Assert.AreEqual(returnValue, controller.RequestFloor(5).Response);
        }

        [TestMethod]
        public void RequestFloor_Returns_Message_If_Exception_Is_Thrown()
        {
            elevatorServiceMock.Setup(x => x.RequestFloor(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
            Assert.IsGreaterThan(0, controller.RequestFloor(-1).Message.Length);
        }

        [TestMethod]
        public void GetNextFloor_Returns_Object_From_Service()
        {
            var returnValue = new Floor(10);
            elevatorServiceMock.Setup(x => x.GetNextFloor(5)).Returns(returnValue);
            Assert.AreEqual(returnValue, controller.GetNextFloor(5).Response);
        }

        [TestMethod]
        public void GetNextFloor_Returns_Message_If_Exception_Is_Thrown()
        {
            elevatorServiceMock.Setup(x => x.GetNextFloor(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
            Assert.IsGreaterThan(0, controller.GetNextFloor(-1).Message.Length);
        }
    }
}
