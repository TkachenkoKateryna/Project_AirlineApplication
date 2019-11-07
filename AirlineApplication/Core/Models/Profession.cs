using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }

        public string Name { get; set; }

        public ICollection<CrewMember> Members { get; set; }

        public Profession()
        {
            Members = new List<CrewMember>();
        }
    }
}