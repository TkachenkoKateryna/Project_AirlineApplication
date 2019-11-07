using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.DTOs
{
    public class CrewMemberDto
    {
        public int CrewMemberId { get; set; }

        public string FullName { get; set; }

        public int ProfessionId { get; set; }

        public bool isWorking { get; set; }

        public ProfessionDto Profession { get; set; }

    }
}