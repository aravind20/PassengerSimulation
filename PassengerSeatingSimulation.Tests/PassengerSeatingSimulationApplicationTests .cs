using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using PassengerSeatingSimulation.Service;
using PassengerSeatingSimulation.Domain;
using System.Collections.Generic;
using PassengerSeatingSimulation.Domain.Dto;

namespace PassengerSeatingSimulation.Tests
{
    [TestClass]
    public class PassengerSeatingSimulationApplicationTests
    {
        private readonly PassengerSeatingService _passengerSeatingService;
        public PassengerSeatingSimulationApplicationTests()
        {

            _passengerSeatingService = new PassengerSeatingService();
        }

        [TestMethod]

        public void When_seatcount_is_greaterThanZero_GeneratePassengers_Method_Generates_Passengers()
        {
            //Arrange
            var application = new Application(_passengerSeatingService);

            //Act
            var result = application.GeneratePassengers(2);

            //Assert
            Assert.IsTrue(result.Count > 0);

        }



    }
}
