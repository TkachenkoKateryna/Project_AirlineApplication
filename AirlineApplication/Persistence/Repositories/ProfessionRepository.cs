using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AirlineApplication.Core.Repositories;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Persistence.Repositories
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Profession> GetAllProfessions()
        {
            return _context.Professions.ToList();
        }
    }
}