using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerSeatingSimulation.Domain.Dto
{
    public class Passenger
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int allocatedSeatNumber { get; set; }
        public int occupiedSeatNumber { get; set; }

    }
}
