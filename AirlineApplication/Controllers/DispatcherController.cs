using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using AirlineApplication.Persistence;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Services;


namespace AirlineApplication.Controllers
{
    [Authorize(Roles ="Admin,Dispatcher")]
    public class DispatcherController : Controller
    {
        private readonly ICrewService _crewService;

        public DispatcherController(ICrewService crewService)
        {
            _crewService = crewService;
        }

        public ActionResult ShowCrews()
        {
            return View(_crewService.GetCrews());
        }

        public ActionResult CreateCrew(int id, string code,string date)
        {
            var viewModel = new CrewViewModel
            {
                FlightId = id,
                FlightCode = code,
                CrewMembers = _crewService.GetFreeCrewMembers(id, date)
            };

            return View("CrewForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCrew(CrewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CrewMembers = _crewService.GetFreeCrewMembers(viewModel.FlightId, viewModel.Date);
                return View("CrewForm", viewModel);
            }
            _crewService.CreateCrew(viewModel);

            return RedirectToAction("ShowCrews", "Dispatcher");
        }

        public ActionResult UpdateCrew(int id, string date)
        {
            var viewModel = new CrewViewModel()
            {
                CrewMembers = _crewService.GetFreeCrewMembers(id, date)
            };

           viewModel = _crewService.FormCrew(id, viewModel);

            return View("CrewForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCrew(CrewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CrewMembers = _crewService.GetFreeCrewMembers(viewModel.FlightId, viewModel.Date);
                return View("CrewForm", viewModel);
            }

            _crewService.UpdateCrew(viewModel);

            return RedirectToAction("ShowCrews", "Dispatcher");
        }
    }
}