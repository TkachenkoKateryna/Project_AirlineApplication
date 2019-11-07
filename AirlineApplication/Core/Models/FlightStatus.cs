using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class FlightStatus
    {
        public int StatusId { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public FlightStatus()
        {
            Flights = new List<Flight>();
        }
    }
}