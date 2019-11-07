using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class Flight
    {
        public int FlightId { get; set; }

        public bool IsDeleted { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public int StatusId { get; set; }

        public virtual FlightStatus FlightStatus { get; set; }

        public virtual ICollection<Route> Airports { get; set; }

        public virtual ICollection<Crew> CrewMembers { get; set; }
    }
}