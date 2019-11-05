using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AirlineApplication.Models;

namespace AirlineApplication.ViewModels
{
    public class CrewViewModel
    {
        public int FlightId { get; set; }

        public DateTime Date { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                return (FlightId != 0) ? "UpdateFlight" : "CreateFlight";
            }
        }

        [Required]
        public string FlightCode { get; set; }

        [Required]
        public int Captain { get; set; }

        [Required]
        public int FirstPilot { get; set; }

        [Required]
        public int Navigator { get; set; }

        [Required]
        public int RadioOperator { get; set; }

        [Required]
        public int MainFlightAttendant { get; set; }

        [Required]
        public int FligthAttendant { get; set; }

        public virtual Profession Profession { get; set; }

        public IEnumerable<Flight> Flights { get; set; }

        public IEnumerable<CrewMember> CrewMembers { get; set; }

        public IEnumerable<Crew> ExistingCrews { get; set; }
    }
}