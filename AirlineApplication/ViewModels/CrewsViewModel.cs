using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Models; 

namespace AirlineApplication.ViewModels
{
    public class CrewsViewModel
    {
        public int CrewId { get; set; }

        public string FlightCode { get; set; }

        public string Captain { get; set; }

        public string FirstPilot { get; set; }

        public string Navigator { get; set; }

        public string RadioOperator { get; set; }

        public string MainFlightAttendant { get; set; }

        public string FligthAttendant { get; set; }

        public IEnumerable<Flight> Flights { get; set; }
    }
}