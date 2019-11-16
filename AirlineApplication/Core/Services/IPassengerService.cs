using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Services
{
    public interface IPassengerService
    {
        void Create(Passenger pas);

        IEnumerable<Passenger> GetPassengers();

        Passenger GetPassenger(int flightid, string userid);
    }
}
