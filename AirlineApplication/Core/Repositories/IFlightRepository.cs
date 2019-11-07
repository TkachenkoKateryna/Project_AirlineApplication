using System.Collections.Generic;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Repositories
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetAllFlights();
        Flight GetFlight(int id);
        void AddFlight(Flight flight);
        void AddFlightRoutes(int flightId,int depId, int landId);
        IEnumerable<Route> FindRoute(int flightId);
        IEnumerable<Crew> FindCrew(int flightId);
    }
}