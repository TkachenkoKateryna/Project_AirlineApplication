using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirlineApplication.Core.ViewModels.Search;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.ViewModels;

namespace AirlineApplication.Core.Services
{
    public interface IFlightService : IDisposable
    {
        IEnumerable<Flight> GetAllFlights();

        IEnumerable<Flight> GetFilteredFlights(string query = null, FlightSearchModel filter = null);

        Flight GetFlight(int id);

        void CreateFlight(FlightViewModel viewModel);

        void UpdateFlight(FlightViewModel viewModel);

        void DeleteFlight(int id);

        IEnumerable<Airport> GetAllAirports();

        IEnumerable<FlightStatus> GetAllStatuses();
    }
}
