using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Services;
using Microsoft.AspNet.Identity;

namespace AirlineApplication.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerService _passervice;
        private readonly IFlightService _flightservice;

        public PassengerController( IPassengerService passervice, IFlightService flightservice)
        {
            _passervice = passervice;
            _flightservice = flightservice;

        }
        [HandleError(ExceptionType = typeof(Exception), View = "FlightError")]
        public ActionResult Register(int id)
        {
            if (_passervice.GetPassenger(id, User.Identity.GetUserId()) != null)
            {
                throw new Exception("You have already registered on this flight");
            }
            Passenger pas = new Passenger
            {
                UserId = User.Identity.GetUserId(),
                FlightId =  id
            };
            _passervice.Create(pas);

            var flight = _flightservice.GetFlight(id);

            var viewModel = new PassangerRegistrationViewModel()
            {
                UserId = User.Identity.GetUserId(),
                FlightCode = flight.Code,
                Departure = flight.Airports.SingleOrDefault(fl => fl.DestinationPoint == true).Airport.Name,
                Landing = flight.Airports.SingleOrDefault(fl => fl.DestinationPoint == false).Airport.Name,
                Date = flight.Date.ToString("dd/MM/YYYY"),
                Time = flight.Date.ToString("HH:mm")
            };
            return View("RegistrationSuccess",  viewModel);
        }

        public ActionResult ShowUserFlights()
        {
            var userFlights = _passervice.GetPassengers().Where(p => p.UserId == User.Identity.GetUserId());

            return View("ShowUserFlights", userFlights);
        }

    }
}