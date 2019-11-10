using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AirlineApplication.Core.Models;
using System.Linq.Expressions;
using AirlineApplication.Controllers;
using System.Web.Mvc;

namespace AirlineApplication.Core.ViewModels
{
    public class CrewViewModel
    {
        public string Action
        {
            get
            {
                Expression<Func<DispatcherController, ActionResult>> update = (c => c.UpdateCrew(this));
                Expression<Func<DispatcherController, ActionResult>> create = (c => c.CreateCrew(this));

                var action = (FirstPilot != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public int FlightId { get; set; }

        public string Date { get; set; }

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
        }
    }
