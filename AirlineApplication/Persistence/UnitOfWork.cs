using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Persistence.Repositories;
using AirlineApplication.Core.Repositories;
using AirlineApplication.Core;

namespace AirlineApplication.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        private IFlightRepository _flightRepository;
        private ICrewRepository _crewRepository;
        private IAirportRepository _airportRepository;
        private IProfessionRepository _professionRepository;
        private IFlightStatusRepository _flightStatusRepository;
        private INotificationRepository _notificationRepository;
        private IPassengerRepository _passengerRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IFlightRepository Flights =>
        _flightRepository ?? (_flightRepository = new FlightRepository(_context));

        public ICrewRepository CrewMembers =>
        _crewRepository ?? (_crewRepository = new CrewRepository(_context));

        public IAirportRepository Airports =>
        _airportRepository ?? (_airportRepository = new AirportRepository(_context));

        public IProfessionRepository Professions =>
        _professionRepository ?? (_professionRepository = new ProfessionRepository(_context));


        public IFlightStatusRepository Statuses =>
        _flightStatusRepository ?? (_flightStatusRepository = new FlightStatusRepository(_context));

        public INotificationRepository Notifications =>
        _notificationRepository ?? (_notificationRepository = new NotificationRepository(_context));

        public IPassengerRepository Passengers =>
        _passengerRepository ?? (_passengerRepository = new PassengerRepository(_context));

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}