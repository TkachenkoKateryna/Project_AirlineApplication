using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.Services;
using AirlineApplication.Core;
using AirlineApplication.Core.ViewModels.Search;
using AirlineApplication.Core.ModelState;
using System.Web.Http;

namespace AirlineApplication.Persistence.Services
{
    public class FlightService : IFlightService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public FlightService(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _unitOfWork.Flights.GetAllFlights();
        }

        public IEnumerable<Flight> GetFilteredFlights(string query = null, FlightSearchModel filter = null)
        {
            var flights = _unitOfWork.Flights.GetAllFlights();

            if (!String.IsNullOrWhiteSpace(query))
            {
                flights = flights.Where(g => g.Code.Contains(query));
            }
            if (filter.Departing.HasValue)
            {
                flights = flights.Where(t => t.Airports.Any(ar => ar.AirportId == filter.Departing &&
                                       ar.DestinationPoint == true));
            }
            if (filter.Landing.HasValue)
            {
                flights = flights.Where(t => t.Airports.Any(ar => ar.AirportId == filter.Landing &&
                        ar.DestinationPoint == false));
            }
            if (filter.FlightStatus.HasValue)
            {
                flights = flights.Where(t => t.StatusId == filter.FlightStatus);
            }
            if (filter.Date.HasValue)
            {
                flights = flights.Where(t => t.Date.Day == filter.Date.Value.Day);
            }

            return flights;
        }

        public Flight GetFlight(int id )
        {
            var flight = _unitOfWork.Flights.GetFlight(id);
            if (flight == null)
            {
                throw new ArgumentException("No flight with such id exists");
            }

            return flight;
        }

        public void CreateFlight(FlightViewModel viewModel)
        {
            if(_unitOfWork.Flights.ExistsFlightWithCode(viewModel.Code))
            {
                throw new ValidationException("Such flight already exists", "");
            }

            _unitOfWork.Flights.AddFlight(Mapper.Map<FlightViewModel, Flight>(viewModel));
            _unitOfWork.Flights.AddFlightRoutes(viewModel.FlightId, viewModel.Departing, viewModel.Landing);
            _unitOfWork.Complete();
        }

        public void UpdateFlight(FlightViewModel viewModel)
        {
            var flight = _unitOfWork.Flights.GetFlight(viewModel.FlightId);
            var route = _unitOfWork.Flights.FindRoute(flight.FlightId);

            if (flight == null)
            {
                throw new ArgumentException("No flight with such id exists");
            }

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

        public void DeleteFlight(int id)
        {
            var flight = _unitOfWork.Flights.GetFlight(id);
            if (flight == null)
            {
                throw new ArgumentException("No flight with such id exists");
            }
            flight.IsDeleted = true;
            _unitOfWork.Complete();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
}
}
