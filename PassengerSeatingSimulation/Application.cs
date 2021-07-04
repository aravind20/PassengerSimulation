using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassengerSeatingSimulation.Domain.Dto;
using PassengerSeatingSimulation.Service.Interfaces;

namespace PassengerSeatingSimulation
{
    public class Application
    {
        protected readonly IPassengerSeatingService _passengerSeatingService;

        public Application(IPassengerSeatingService passengerSeatingService)
        {
            _passengerSeatingService = passengerSeatingService;
        }

        /// <summary>
        /// This is the Entry point of Passenger seating simulation application
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {

            string simulationCount;
            int counter;

            Console.WriteLine("****************************************************");
            Console.WriteLine("******* Crazy Passenger problem ********************");
            Console.WriteLine("****************************************************");

            Console.WriteLine(" ");

            Console.WriteLine("****************************************************");
            Console.WriteLine("Enter how many times you like to run this simulation");
            Console.WriteLine("****************************************************");

            simulationCount = Console.ReadLine();
            counter = Convert.ToInt32(simulationCount);

            Task<float> task = GetProbabilityForLastPassengerToGetOwnSeat(counter);
            float result = await task;

            Console.WriteLine(" ");

            Console.WriteLine("Probability for last passenger to get his/her own seat is : " + result);

        }

        /// <summary>
        ///  This method generates passengers based on seat count and calculates probability of last passenger to get own seat 
        /// </summary>
        /// <param name="counter"></param>
        /// <returns></returns>

        public async Task<float> GetProbabilityForLastPassengerToGetOwnSeat(int counter)
        {
            float simulationResult = 0;
            int seatCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("SeatCount"));
            try
            {
                bool[] results = new bool[counter];
                await Task.Run(() =>
                {
                    for (int i = 0; i < counter; i++)
                    {
                        var passengers = GeneratePassengers(seatCount);
                        var result = _passengerSeatingService.IsLastPassengerGotOwnSeat(passengers);
                        results[i] = result;
                    }
                });

                simulationResult = results.Count(c => c == true) / counter;

            }

            catch (Exception ex)
            {
                //Handle exception
                //Log error 
            }

            return simulationResult;

        }

        /// <summary>
        /// This method generates passengers based on seat count
        /// </summary>
        /// <param name="seatCount"></param>
        /// <returns></returns>
        public List<Passenger> GeneratePassengers(int seatCount)
        {
            var passengers = new List<Passenger>();
            var excludedSeatNumbers = new List<int>();
            var occupiedSeatNumbers = new List<int>();
            for (int i = 0; i < seatCount; i++)
            {
                //Populating passenger object
                //Note: as of now storing id as index of iteration 1.2..3...etc
                // allocated  and occupied seat numbers will be unique , once taken it will be excluded 
                var passenger = new Passenger
                {
                    id = i + 1,
                    allocatedSeatNumber = AllocateRandomSeatNumber(1, seatCount, excludedSeatNumbers),
                    occupiedSeatNumber = AllocateRandomSeatNumber(1, seatCount, occupiedSeatNumbers)
                };
                excludedSeatNumbers.Add(passenger.allocatedSeatNumber);
                occupiedSeatNumbers.Add(passenger.occupiedSeatNumber);
                passengers.Add(passenger);

            }

            return passengers;
        }



        /// <summary>
        /// This method generates random seat number and allocates to passenger
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="excludeList"></param>
        /// <returns></returns>
        private int AllocateRandomSeatNumber(int min, int max , IEnumerable<int> excludeList)
        {
            Random random = new Random();
            return Enumerable
                .Range(min, max)
                .Where(i => !excludeList.Contains(i))
                .OrderBy(i => random.Next())
                .Take(1).First();
                
        }
    }
}
