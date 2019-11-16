using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        public int FlightId { get; set; }

        public string UserId { get; set; }

        public Flight Flight { get; set; }

        public ApplicationUser User { get; set; }
    }
}