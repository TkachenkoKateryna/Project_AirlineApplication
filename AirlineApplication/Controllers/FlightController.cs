using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using AirlineApplication.Models;
using AirlineApplication.ViewModels;

namespace AirlineApplication.Controllers
{
    public class FlightController : Controller
    {
        private ApplicationDbContext _context;

        public FlightController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult ShowAllFlights()
        {
            var flights = _context.Flights.Include(st => st.FlightStatus)
                                          .Include(m => m.CrewMembers.Select(y => y.CrewMember.Profession))
                                          .Include(a => a.Airports).ToList();
            return View(flights);
        }

        [Authorize]
        public ActionResult CreateFlight ()
        {
            var viewModel = new FlightViewModel
            {
                Airports = _context.Airports.ToList(),
                Statuses = _context.FlightStatuses.ToList(),
                Heading = "Add a flight"
            };

            return View("FlightForm", viewModel);
        }

        [Authorize]
        public ActionResult UpdateFlight(int id)
        {
            var flight = _context.Flights.Single(f => f.FlightId == id);

            var viewModel = new FlightViewModel
            {
                FlightId = flight.FlightId,
                Airports = _context.Airports.ToList(),
                Statuses = _context.FlightStatuses.ToList(),
                Date = flight.Date.ToString("dd/MM/yyyy"),
                Time = flight.Date.ToString("HH:mm"),
                Code = flight.Code,
                Departing = flight.Airports.Single(f => f.DestinationPoint == true && f.FlightId == id).AirportId,
                Landing = flight.Airports.Single(f => f.DestinationPoint == false && f.FlightId == id).AirportId,
                FlightStatus = flight.StatusId,
                Heading = "Edit a flight",
             
            };

            return View("FlightForm",viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFlight(FlightViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Airports = _context.Airports.ToList();
                viewModel.Statuses = _context.FlightStatuses.ToList();
                return View("FlightForm", viewModel);
            }

            var flight = new Flight
            {
                Code = viewModel.Code,
                Date = viewModel.GetDateTime(),
                StatusId = viewModel.FlightStatus
            };

            _context.Flights.Add(flight);
            _context.Routes.Add(new Route { FlightId = flight.FlightId, AirportId = viewModel.Departing, DestinationPoint = true });
            _context.Routes.Add(new Route { FlightId = flight.FlightId, AirportId = viewModel.Landing, DestinationPoint = false });
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFlight(FlightViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Airports = _context.Airports.ToList();
                viewModel.Statuses = _context.FlightStatuses.ToList();
                return View("FlightForm", viewModel);
            }

            var flight = _context.Flights.Single(f => f.FlightId == viewModel.FlightId);

            flight.Code = viewModel.Code;
            flight.Date = viewModel.GetDateTime();
            flight.StatusId = viewModel.FlightStatus;

            var depId =_context.Routes.Single(r => r.FlightId == viewModel.FlightId && r.DestinationPoint == true);
            depId.AirportId = viewModel.Departing;
            var landId = _context.Routes.Single(r => r.FlightId == viewModel.FlightId && r.DestinationPoint == false);
            landId.AirportId = viewModel.Landing;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}