using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineApplication.Core.DTOs;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Core.Services
{
    public interface ICrewMemberService : IDisposable
    {
        IEnumerable<CrewMemberDto> GetCrewMembers();

        CrewMemberDto GetCrewMember(int crewMemberId);

        void CreateCrewMember(CrewMember member);

        void UpdateCrewMember(int id, CrewMemberDto memberDto);

        void Delete(int id);
    }
}
