using System;
using System.Linq;
using System.Collections.Generic;
using PassengerSeatingSimulation.Domain.Dto;
using PassengerSeatingSimulation.Service.Interfaces;

namespace PassengerSeatingSimulation.Service
{
    public class PassengerSeatingService : IPassengerSeatingService
    {
        /// <summary>
        /// returns last passengers status
        /// </summary>
        /// <param name="passengers"></param>
        /// <returns></returns>
        public bool  IsLastPassengerGotOwnSeat(List<Passenger> passengers)
        {
            var lastPassenger = passengers.Last();
            return lastPassenger.allocatedSeatNumber == lastPassenger.occupiedSeatNumber;
        }
    }
}
