using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }


        public Flight(string flightNumber, string departureCity, string arrivalCity, DateTime departureTime, int availableSeats)
        {
            FlightNumber = flightNumber;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartureTime = departureTime;
            AvailableSeats = availableSeats;
        }

       

    }
}
