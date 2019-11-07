using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineApplication.Core;
using AirlineApplication.Core.DTOs;
using AirlineApplication.Core.Models;
using AutoMapper;

namespace AirlineApplication.Controllers.Api
{
    public class ProfessionController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET / api/crewmemebers
        public IEnumerable<Profession> GetCrewMembers()
        {
            return _unitOfWork.Professions.GetAllProfessions().Select(Mapper.Map<Profession, Profession>);
        }
    }
}
