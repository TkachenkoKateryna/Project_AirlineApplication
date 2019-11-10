using System.Collections.Generic;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Repositories
{
    public interface IAirportRepository
    {
        IEnumerable<Airport> GetAllAirports();
    }
}
