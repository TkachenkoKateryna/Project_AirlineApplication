using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineApplication.Models;

namespace AirlineApplication.Controllers.Api
{ 

    public class FlightsController : ApiController
    {
        private ApplicationDbContext _context;

        public FlightsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var flight = _context.Flights.Single(f => f.FlightId == id);
            flight.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
