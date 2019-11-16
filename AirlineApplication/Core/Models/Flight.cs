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

        public  FlightStatus FlightStatus { get; set; }

        public  ICollection<Route> Airports { get; set; }

        public  ICollection<Crew> CrewMembers { get; set; }

        public ICollection <Passenger> Passengers { get; set; }
    }
}