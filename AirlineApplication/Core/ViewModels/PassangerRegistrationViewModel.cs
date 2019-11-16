using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineApplication.Core.ViewModels
{
    public class PassangerRegistrationViewModel
    {
        public string UserId { get; set; }

        public string FlightCode {get;set;}

        public string Departure { get; set; }

        public string Landing { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}