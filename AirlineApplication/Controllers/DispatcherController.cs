using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using AirlineApplication.ViewModels;
using AirlineApplication.Models;


namespace AirlineApplication.Controllers
{
    public class DispatcherController : Controller
    {
        private ApplicationDbContext _context;

        public DispatcherController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult ShowAllCrews()
        {
            List<CrewsViewModel> list = new List<CrewsViewModel>();

            var flights = _context.Flights.ToList();

            foreach (var crew in flights)
            {
                var model = new CrewsViewModel();

                model.CrewId = crew.FlightId;
                model.FlightCode = crew.Code;
                foreach (var cr in crew.CrewMembers)
                {
                    switch (cr.CrewMember.ProfessionId)
                    {
                        case 1:
                            model.Captain = cr.CrewMember.FullName;
                            break;
                        case 2:
                            model.FirstPilot = cr.CrewMember.FullName;
                            break;
                        case 3:
                            model.Navigator = cr.CrewMember.FullName;
                            break;
                        case 4:
                            model.RadioOperator = cr.CrewMember.FullName;
                            break;
                        case 5:
                            model.MainFlightAttendant = cr.CrewMember.FullName;
                            break;
                        case 6:
                            model.FligthAttendant = cr.CrewMember.FullName;
                            break;
                    }
                }
                list.Add(model);
            }
            return View(list);
        }

        public ActionResult CreateCrew()
        {
            var viewModel = new CrewViewModel
            {
                CrewMembers = _context.CrewMembers.ToList(),
                Heading = "Add a flight"
            };

            return View("CrewForm", viewModel);
        }

        [Authorize]
        public ActionResult UpdateCrew(int id)
        {
            var flight = _context.Flights.SingleOrDefault(f => f.FlightId == id);

            var viewModel = new CrewViewModel();

            viewModel.FlightId = flight.FlightId;
            viewModel.Date = flight.Date;
            viewModel.FlightCode = flight.Code;
            viewModel.Captain = flight.CrewMembers.SingleOrDefault(f => f.CrewMember.ProfessionId == 1).CrewMemberId;
            viewModel.FirstPilot = flight.CrewMembers.SingleOrDefault(f => f.CrewMember.ProfessionId == 2).CrewMemberId;
            viewModel.Navigator = flight.CrewMembers.SingleOrDefault(f => f.CrewMember.ProfessionId == 3).CrewMemberId;
            viewModel.RadioOperator = flight.CrewMembers.SingleOrDefault(f => f.CrewMember.ProfessionId == 4).CrewMemberId;
            viewModel.MainFlightAttendant = flight.CrewMembers.SingleOrDefault(f => f.CrewMember.ProfessionId == 5).CrewMemberId;
            viewModel.FligthAttendant = flight.CrewMembers.SingleOrDefault(f => f.CrewMember.ProfessionId == 5).CrewMemberId;
            viewModel.CrewMembers = _context.CrewMembers.ToList();
            viewModel.Heading = "Edit a Crew";


            return View("CrewForm", viewModel);
        }
    }
}