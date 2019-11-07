using System.Collections.Generic;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Repositories
{
    public interface ICrewRepository
    {
        IEnumerable<CrewMember> GetAllCrewMembers();
        void CreateCrew(Flight flight, List<int> members);
        CrewMember GetCrewMember(int id);
        void CreateCrewMember(CrewMember member);

    }
}
