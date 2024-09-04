using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
    internal class Reservation
    {
        public string ReservationNumber { get; set; }
        public string PassengerName { get; set; }
        public Flight Flight { get; set; }

        public Reservation(string reservationNumber, string passengerName, Flight flight)
        {
            ReservationNumber = reservationNumber;
            PassengerName = passengerName;
            Flight = flight;
        }

    }
}
