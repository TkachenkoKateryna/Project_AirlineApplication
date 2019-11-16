using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.Repositories;
using AirlineApplication.Core.Models;
using System.Data.Entity;
namespace AirlineApplication.Persistence.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext _context;

        public PassengerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreatePassenger(Passenger pas)
        {
            
            _context.Passengers.Add(pas);
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            return _context.Passengers
                .Include(p => p.Flight)
                .ToList();
        }

        public Passenger GetPassenger(int flightid, string userid )
        {
            return _context.Passengers
                  .Include(p => p.Flight)
                  .Include(u => u.User)
                  .SingleOrDefault(p => p.FlightId == flightid && p.UserId == userid);
        }
    }
}