﻿using System;
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
    public class DispatcherController : Controller
    {
        private readonly ICrewService _crewService;

        public DispatcherController(ICrewService crewService)
        {
            _crewService = crewService;
        }

        public ActionResult ShowCrews(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var crews = _crewService.GetCrews();

            return View(_crewService.Sort(crews,sortOrder));
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

        public ActionResult Sort(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var crews = _crewService.GetCrews();
          
            return RedirectToAction("");
        }
    }
}