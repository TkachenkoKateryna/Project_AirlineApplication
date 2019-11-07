using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.ViewModels;

namespace AirlineApplication.Core.Services
{
    public interface IFlightService : IDisposable
    {
        IEnumerable<Flight> GetAllFlights(string query = null);
        Flight GetFlight(int id);
        IEnumerable<Airport> GetAllAirports();
        IEnumerable<FlightStatus> GetAllStatuses();
        void CreateFlight(FlightViewModel viewModel);
        void UpdateFlight(FlightViewModel viewModel);
    }
}
