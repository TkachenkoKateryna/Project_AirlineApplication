using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AirlineApplication.Core.Repositories;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Persistence.Repositories
{
    public class CrewRepository : ICrewRepository
    {
        private readonly ApplicationDbContext _context;

        public CrewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CrewMember> GetAllCrewMembers()
        {
            return _context.CrewMembers.Include(m => m.Profession)
                .Include(m => m.Flights
                .Select(f => f.Flight))
                .ToList();
        }

        public IEnumerable<CrewMember> GetAllFreeCrewMembers(Flight flight)
        {
            return _context.CrewMembers.Include(m => m.Profession)
                .Include(m => m.Flights)
                .Where(cr => !cr.Flights.Any(fl => fl.Flight.Date == flight.Date))
                .ToList();
        }

        public CrewMember GetCrewMember(int id)
        {
            return _context.CrewMembers.Include(m => m.Profession)
                  .Include(m => m.Flights)
                  .FirstOrDefault(m => m.CrewMemberId == id);
        }

        public void CreateCrewMember(CrewMember member)
        {
            _context.CrewMembers.Add(member);
        }

        public void AddCrewMember(CrewMember member)
        {
            _context.CrewMembers.Add(member);
        }

        public void CreateCrew(Flight flight, List<int> members)
        {
            foreach(var m in members)
            {
                var member = (new Crew
                {
                    FlightId = flight.FlightId,
                    CrewMemberId = m
                });
                _context.Crew.Add(member);
            }
        }
    }
}