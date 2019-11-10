using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineApplication.Core;
using AirlineApplication.Core.Services;
using AirlineApplication.Core.Models;
using AutoMapper;

namespace AirlineApplication.Controllers.Api
{
    public class ProfessionController : ApiController
    {
        private readonly IProfessionService _profService;

        public ProfessionController(IProfessionService profService)
        {
            _profService = profService;
        }

        public IEnumerable<Profession> GetCrewMembers()
        {
            return _profService.GetProfessions();
        }
    }
}
