using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
    internal class FlightReservationSystem
    {

        public List<Flight> Flights { get; set; }
        public List<Reservation> Reservations { get; set; }

        public FlightReservationSystem()
        {
            Flights = new List<Flight>();

            Reservations = new List<Reservation>();
        }

        public List<Flight> SearchFlights(string departureCity, string arrivalCity, DateTime departureDate)
        {
            return Flights.Where(f => f.DepartureCity.Equals(departureCity, StringComparison.OrdinalIgnoreCase)
                                    && f.ArrivalCity.Equals(arrivalCity, StringComparison.OrdinalIgnoreCase)
                                    && f.DepartureTime.Date == departureDate.Date).ToList();
        }

        public Reservation BookTicket(Flight flight, string passengerName)
        {
            if (flight.AvailableSeats > 0)
            {
                flight.AvailableSeats--;

                var reservation = new Reservation(Guid.NewGuid().ToString(), passengerName, flight);

                Reservations.Add(reservation);

                return reservation;
            }
            else
            {
                Console.WriteLine("There isn't seats on this flight");
                return null;
            }
        }

        public bool CancelReservation(string reservationNumber)
        {
            var reservation = Reservations.FirstOrDefault(r => r.ReservationNumber == reservationNumber);

            if (reservation != null)
            {
                reservation.Flight.AvailableSeats++;
                Reservations.Remove(reservation);
                return true;
            }

            return false;
        }

    }
}
