using AirlineApplication.Core.Repositories;
using System;

namespace AirlineApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IFlightRepository Flights { get; }
        IAirportRepository Airports { get; }
        ICrewRepository CrewMembers { get; }
        IProfessionRepository Professions { get; }
        IFlightStatusRepository Statuses { get; }
        void Complete();
    }
}