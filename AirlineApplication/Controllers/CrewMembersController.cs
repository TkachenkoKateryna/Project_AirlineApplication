using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineApplication.Core.Services;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.DTOs;

namespace AirlineApplication.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class CrewMembersController : Controller
    {
        private readonly ICrewMemberService _crewMemberService;

        public CrewMembersController(ICrewMemberService crewMemberService)
        {
            _crewMemberService = crewMemberService;
        }

        public ActionResult ShowMembers()
        {
            return View();
        }


        public ActionResult EditMember(int id)
        {
            var member = _crewMemberService.GetCrewMember(id);

            var viewModel = new CrewMemberViewModel()
            {
                CrewMemberId = id,
                FullName = member.FullName,
                ProfessionId = member.ProfessionId,
            };
            return View("UpdateMember", viewModel);
        }

        public ActionResult CreateMember()
        {
            return View();
        }
    }
}