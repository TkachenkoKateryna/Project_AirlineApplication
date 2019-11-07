using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class Airport
    {
        public int AirportId { get; set; }

        public string IATA { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public virtual ICollection<Route> Flights { get; set; }
    }
}