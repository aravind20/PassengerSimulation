using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassengerSeatingSimulation.Domain.Dto;

namespace PassengerSeatingSimulation.Service.Interfaces
{
    public interface IPassengerSeatingService
    {
        public bool IsLastPassengerGotOwnSeat(List<Passenger> passengers);
    }
}
