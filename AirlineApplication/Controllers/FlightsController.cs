using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web.Mvc;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Services;

namespace AirlineApplication.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightService _service;

        public FlightsController(IFlightService service)
        {
            _service = service;
        }

        public ActionResult ShowFlights(string query = null)
        {
            var viewModel = new FlightsViewModel
            {
                Heading = "All flights",
                Flights = _service.GetAllFlights()
            };

            if (User.IsInRole(RoleName.Admin))
                return View("FlightsList", viewModel);
            return View("ReadOnlyFlightsList", viewModel);
        }

        [HttpPost]
        public ActionResult Search(FlightsViewModel viewModel)
        {
            return RedirectToAction("ShowFlights", "Flight", new { query = viewModel.SearchTerm });
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult CreateFlight()
        {
            var viewModel = new FlightViewModel
            {
                Airports = _service.GetAllAirports(),
                Statuses = _service.GetAllStatuses(),
                Heading = "Add a flight"
            };

            return View("FlightForm", viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult UpdateFlight(int id)
        {
            var flight = _service.GetFlight(id);

            var viewModel = new FlightViewModel
            {
                FlightId = flight.FlightId,
                Airports = _service.GetAllAirports(),
                Statuses = _service.GetAllStatuses(),
                Date = flight.Date.ToString("dd/MM/yyyy"),
                Time = flight.Date.ToString("HH:mm"),
                Code = flight.Code,
                Departing = flight.Airports.Single(f => f.DestinationPoint == true && f.FlightId == id).AirportId,
                Landing = flight.Airports.Single(f => f.DestinationPoint == false && f.FlightId == id).AirportId,
                StatusId = flight.StatusId,
                Heading = "Edit a flight",
            };

            return View("FlightForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFlight(FlightViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Airports = _service.GetAllAirports();
                viewModel.Statuses = _service.GetAllStatuses();
                return View("FlightForm", viewModel);
            }

            _service.CreateFlight(viewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFlight(FlightViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Airports = _service.GetAllAirports();
                viewModel.Statuses = _service.GetAllStatuses();
                return View("FlightForm", viewModel);
            }

            _service.UpdateFlight(viewModel);

            return RedirectToAction("ShowFlights", "Flights");
        }
    }
}