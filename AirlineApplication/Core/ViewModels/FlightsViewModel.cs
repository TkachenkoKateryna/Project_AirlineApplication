using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.ViewModels
{
    public class FlightsViewModel
    {
        public IEnumerable<Flight> Flights { get; set; }

        public IEnumerable<Airport> Airports { get; set; }
 
        public IEnumerable<FlightStatus> Statuses { get; set; }

        public string UserId { get; set; }

        public string Heading { get; set; }

        public FlightSearchModel Filter { get; set; }

        public string SearchTerm { get; set; }
    }
}