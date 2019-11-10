using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class CrewMember
    {
        public int CrewMemberId { get; set; }

        public string FullName { get; set; }

        public int ProfessionId { get; set; }

        public bool isNotWorking { get; set; }

        public Profession Profession { get; set; }

        public ICollection<Crew> Flights { get; set; }
    }
}