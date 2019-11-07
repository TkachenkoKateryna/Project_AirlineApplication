using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace AirlineApplication.Core.ViewModels
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                return (FlightId != 0) ? "UpdateFlight" : "CreateFlight";
            }
        }

        [Required]
        public string Code { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int Departing { get; set; }

        [Required]
        public int Landing { get; set; }

        public IEnumerable<FlightStatus> Statuses { get; set; }

        public IEnumerable<Airport> Airports { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time)); 
        }
    }
}