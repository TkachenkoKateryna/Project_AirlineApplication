using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.ViewModels
{
    public class CrewMemberViewModel
    {
        public int CrewMemberId { get; set; }

        public int ProfessionId { get; set; }

        public string FullName { get; set; }
    }
}