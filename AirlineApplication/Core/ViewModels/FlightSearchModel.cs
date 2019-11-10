using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.ViewModels
{
    public class FlightSearchModel
    {
        public int? Departing { get; set; }

        public int? Landing { get; set; }

        public int? FlightStatus { get; set; }

        public DateTime? Date { get; set; }
    }
}