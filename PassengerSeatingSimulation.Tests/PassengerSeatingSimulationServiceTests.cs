using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using PassengerSeatingSimulation.Service;
using PassengerSeatingSimulation.Domain;
using System.Collections.Generic;
using PassengerSeatingSimulation.Domain.Dto;

namespace PassengerSeatingSimulation.Tests
{
    [TestClass]
    public class PassengerSeatingSimulationServiceTests
    {
        private readonly PassengerSeatingService _passengerSeatingService;
        public PassengerSeatingSimulationServiceTests()
        {
            _passengerSeatingService = new PassengerSeatingService();
        }

        [TestMethod]
        public void When_LastPassenger_occupiesAllocatedSeat_SeatingService_Returns_True()
        {

            //Arrange
            var passengers = new List<Passenger>()
            {
                new Passenger(){ id =1 , allocatedSeatNumber = 1 , firstName ="tom" , lastName="Heinez" ,occupiedSeatNumber = 1 },
                new Passenger(){ id =2 , allocatedSeatNumber = 2 , firstName ="Peter" , lastName="Heinez" ,occupiedSeatNumber = 2  },

            };

            //Act 
            var result = _passengerSeatingService.IsLastPassengerGotOwnSeat(passengers);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void When_LastPassenger_NotoccupiesAllocatedSeat_SeatingService_Returns_False()
        {

            //Arrange
            var passengers = new List<Passenger>()
            {
                new Passenger(){ id =1 , allocatedSeatNumber = 1 , firstName ="tom" , lastName="Heinez" ,occupiedSeatNumber = 2 },
                new Passenger(){ id =2 , allocatedSeatNumber = 2 , firstName ="Peter" , lastName="Heinez" ,occupiedSeatNumber = 1  },

            };

            //Act 
            var result = _passengerSeatingService.IsLastPassengerGotOwnSeat(passengers);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
