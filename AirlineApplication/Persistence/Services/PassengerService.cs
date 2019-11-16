using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.Services;
using AirlineApplication.Core;
using AirlineApplication.Core.ModelState;
using System.Configuration.Provider;

namespace AirlineApplication.Persistence.Services
{
    public class PassengerService : IPassengerService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public PassengerService(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            return _unitOfWork.Passengers.GetPassengers();
        }

        public void Create(Passenger pas)
        {
            _unitOfWork.Passengers.CreatePassenger(pas);

            _unitOfWork.Complete();
        }

        public Passenger GetPassenger(int flightid, string userid)
        {
            return _unitOfWork.Passengers.GetPassenger(flightid, userid);
        }
    }
}