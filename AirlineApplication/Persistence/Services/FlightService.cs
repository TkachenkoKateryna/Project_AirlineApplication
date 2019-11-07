using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.Services;
using AirlineApplication.Core;

namespace AirlineApplication.Persistence.Services
{
    public class FlightService : IFlightService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public FlightService(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IEnumerable<Flight> GetAllFlights(string query = null)
        {
            var flights = _unitOfWork.Flights.GetAllFlights();
            if (!String.IsNullOrWhiteSpace(query))
            {
                flights = flights.Where(g => g.Code.Contains(query));
            }
            return flights;
        }

        public Flight GetFlight(int id )
        {
            return _unitOfWork.Flights.GetFlight(id);
        }

        public void CreateFlight(FlightViewModel viewModel)
        {
            _unitOfWork.Flights.AddFlight(Mapper.Map<FlightViewModel, Flight>(viewModel));
            _unitOfWork.Flights.AddFlightRoutes(viewModel.FlightId, viewModel.Departing, viewModel.Landing);
            _unitOfWork.Complete();
        }

        public void UpdateFlight(FlightViewModel viewModel)
        {
            var flight = _unitOfWork.Flights.GetFlight(viewModel.FlightId);
            var route = _unitOfWork.Flights.FindRoute(flight.FlightId);

            flight.Code = viewModel.Code;
            flight.Date = viewModel.GetDateTime();
            flight.StatusId = viewModel.StatusId;

            foreach (var r in route)
            {
                r.AirportId =  r.DestinationPoint == true ?  viewModel.Departing : viewModel.Landing;
            }

            _unitOfWork.Complete();
        }

        public IEnumerable<Airport> GetAllAirports()
        {
            return _unitOfWork.Airports.GetAllAirports();
        }

        public IEnumerable<FlightStatus> GetAllStatuses()
        {
            return  _unitOfWork.Statuses.GetAllStatuses();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
}
}
