using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Models
{
    public class Crew
    {
        public int CrewtId { get; set; }

        public int FlightId { get; set; }

        public int CrewMemberId { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual CrewMember CrewMember { get; set; }
    }
}