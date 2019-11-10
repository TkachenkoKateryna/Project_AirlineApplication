﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class Crew
    {
        public int CrewtId { get; set; }

        public int FlightId { get; set; }

        public int CrewMemberId { get; set; }

        public Flight Flight { get; set; }

        public CrewMember CrewMember { get; set; }
    }
}