using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AirlineApplication.Core.Repositories;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Persistence.Repositories
{
    public class FlightStatusRepository : IFlightStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FlightStatus> GetAllStatuses()
        {
            return _context.FlightStatuses.ToList();
        }
    }
}