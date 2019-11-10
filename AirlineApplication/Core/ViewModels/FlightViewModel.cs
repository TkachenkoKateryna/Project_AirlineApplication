using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using AirlineApplication.Controllers;
using System.Web.Mvc;

namespace AirlineApplication.Core.ViewModels
{
    public class FlightViewModel
    {
        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<FlightsController, ActionResult>> update = (c => c.UpdateFlight(this));
                Expression<Func<FlightsController, ActionResult>> create = (c => c.CreateFlight(this));

                var action = (FlightId != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public int FlightId { get; set; }

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