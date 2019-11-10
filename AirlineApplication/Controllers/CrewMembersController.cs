using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineApplication.Core;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class CrewMembersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrewMembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult ShowMembers()
        {
            return View();
        }

        public ActionResult EditMember(int id)
        {
            var viewModel = new CrewMemberViewModel()
            {
                CrewMemberId = id,
                FullName = _unitOfWork.CrewMembers.GetCrewMember(id).FullName,
                ProfessionId = _unitOfWork.CrewMembers.GetCrewMember(id).ProfessionId
            };
            return View("UpdateMember", viewModel);
        }

        public ActionResult CreateMember()
        {
            return View();
        }
    }
}