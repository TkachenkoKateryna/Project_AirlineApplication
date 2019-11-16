using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AirlineApplication.Core.Repositories;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Persistence.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights.Include(st => st.FlightStatus)
                        .Include(m => m.CrewMembers.Select(y => y.CrewMember))
                        .Include(a => a.Airports.Select(ar => ar.Airport))
                        .ToList();
        }

        public Flight GetFlight(int id)
        {
            return _context.Flights.Include(st => st.FlightStatus)
                 .Include(m => m.CrewMembers.Select(y => y.CrewMember.Profession))
                 .Include(a => a.Airports.Select(y => y.Airport))
                 .SingleOrDefault(f => f.FlightId == id);
        }

        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);

        }

        public void AddFlightRoutes(int flightId,int depId, int landId)
        {
            _context.Routes.Add(new Route { FlightId = flightId, AirportId = depId, DestinationPoint = true });
            _context.Routes.Add(new Route { FlightId = flightId, AirportId = landId, DestinationPoint = false });
        }

        public IEnumerable<Route> FindRoute(int flightId)
        {
            return _context.Routes.Where(r => r.FlightId == flightId)
                .ToList();
        }

        public IEnumerable<Crew> FindCrew(int flightId)
        {
            return _context.Crew.Where(r => r.FlightId == flightId)
                .Include(cr => cr.CrewMember)
                .Include(cr=>cr.Flight)
                .ToList();
        }

        public bool ExistsFlightWithCode(string code)
        {
            return _context.Flights.Any(fl => fl.Code == code);
        }
    }
}