using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.ViewModels
{
    public class FlightsViewModel
    {
        public IEnumerable<Flight> Flights {get;set;}
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}