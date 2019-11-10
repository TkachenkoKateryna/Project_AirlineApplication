using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineApplication.Core;
using AirlineApplication.Core.Services;
using AirlineApplication.Core.ViewModels;
using AutoMapper;

namespace AirlineApplication.Controllers.Api
{
    public class CrewsController : ApiController
    {
            private readonly ICrewService _crewService;

            public CrewsController(ICrewService profService)
            {
                _crewService = profService;
            }

            public IEnumerable<CrewsViewModel> GetCrews()
            {
                return _crewService.GetCrews();
            }
        }
}
