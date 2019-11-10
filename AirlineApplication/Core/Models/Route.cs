using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class Route
    {
        public int RouteId { get; set; }

        public int FlightId { get; set; }

        public int AirportId { get; set; }

        public  Flight Flight { get; set; }

        public  Airport Airport { get; set; }

        public bool DestinationPoint { get; set; }

        public void Modify(int airportId)
        {
            AirportId = airportId;
        }
    }
}