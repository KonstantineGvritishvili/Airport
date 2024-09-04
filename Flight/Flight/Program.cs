using Flight;
namespace Flight;

public class Program
{
    static void Main(string[] args)
    {
        var system = new FlightReservationSystem();
        system.Flights.Add(new Flight("An55", "Tbilisi", "London", new DateTime(2024, 7, 1, 10, 0, 0), 10));
        system.Flights.Add(new Flight("rg60", "Dubai", "Maiami", new DateTime(2024, 7, 1, 15, 0, 0), 20));
        system.Flights.Add(new Flight("fl032", "New York", "San Francisco", new DateTime(2024, 7, 1, 18, 0, 0), 5));

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Search for flights");
            Console.WriteLine("2. Book a ticket");
            Console.WriteLine("3. Cancel a reservation");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter departure city: ");
                    var departureCity = Console.ReadLine();
                    Console.Write("Enter arrival city: ");
                    var arrivalCity = Console.ReadLine();
                    Console.Write("Enter departure date (yyyy-mm-dd): ");
                    var departureDate = DateTime.Parse(Console.ReadLine());
                    var flights = system.SearchFlights(departureCity, arrivalCity, departureDate);
                    if (flights.Any())
                    {
                        Console.WriteLine("Available flights:");
                        foreach (var flight in flights)
                        {
                            Console.WriteLine($"FlightNumber: {flight.FlightNumber}, Departure: {flight.DepartureCity}, Arrival: {flight.ArrivalCity}, DepartureTime: {flight.DepartureTime}, AvailableSeats: {flight.AvailableSeats}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No flights found.");
                    }
                    break;
                case "2":
                    Console.Write("Enter flight number: ");
                    var flightNumber = Console.ReadLine();
                    var selectedFlight = system.Flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
                    if (selectedFlight != null)
                    {
                        Console.Write("Enter passenger name: ");
                        var passengerName = Console.ReadLine();
                        var reservation = system.BookTicket(selectedFlight, passengerName);
                        if (reservation != null)
                        {
                            Console.WriteLine($"Reservation successful! Reservation number: {reservation.ReservationNumber}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Flight not found.");
                    }
                    break;
                case "3":
                    Console.Write("Enter reservation number: ");
                    var reservationNumber = Console.ReadLine();
                    if (system.CancelReservation(reservationNumber))
                    {
                        Console.WriteLine("Reservation cancelled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Reservation not found.");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}