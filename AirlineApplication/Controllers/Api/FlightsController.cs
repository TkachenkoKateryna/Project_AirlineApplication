using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineApplication.Core.Services;

namespace AirlineApplication.Controllers.Api
{ 
    public class FlightsController : ApiController
    {
        private readonly IFlightService _service;

        public FlightsController(IFlightService service)
        {
            _service = service;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            _service.DeleteFlight(id);

            return Ok();
        }
    }
}
