using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Repositories
{
    public interface IPassengerRepository 
    {
        void CreatePassenger(Passenger pas);

        IEnumerable<Passenger> GetPassengers();

        Passenger GetPassenger(int flightid, string userid);
    }

   
}