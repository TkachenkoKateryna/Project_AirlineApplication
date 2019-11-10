using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AirlineApplication.Core.DTOs;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.Services;
using AirlineApplication.Core;
using AirlineApplication.Core.ModelState;

namespace AirlineApplication.Persistence.Services
{
    public class CrewMemberService : ICrewMemberService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public CrewMemberService(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IEnumerable<CrewMemberDto> GetCrewMembers()
        {
            return _unitOfWork.CrewMembers.GetAllCrewMembers()
                .Select(Mapper.Map<CrewMember, CrewMemberDto>);
        }

        public CrewMemberDto GetCrewMember(int crewMemberId)
        {
            var member = _unitOfWork.CrewMembers.GetCrewMember(crewMemberId);

            if (member == null)
            {
                throw new ArgumentException("There is no crew member with such id");
            }

            return Mapper.Map<CrewMember, CrewMemberDto>(member);
        }

        public void CreateCrewMember(CrewMember member)
        {
            _unitOfWork.CrewMembers.CreateCrewMember(member);
            _unitOfWork.Complete();
        }

        public void UpdateCrewMember(int id, CrewMemberDto memberDto)
        {
            var memberInDb = _unitOfWork.CrewMembers.GetCrewMember(id);

            if (memberInDb == null)
            {
                throw new ArgumentException("There is no crew member with such id");
            }

            Mapper.Map(memberDto, memberInDb);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var member = _unitOfWork.CrewMembers.GetCrewMember(id);
            if (member == null)
            {
                throw new ArgumentException("No member with such id exists");
            }
            if (member.Flights.Any(fl => fl.Flight.Date >= DateTime.Now))
            {
                throw new ValidationException("Crew member has flight.It cannot be fired now", "");
            }
            if (member.Flights.Any(fl => fl.Flight.StatusId == 1))
            {
                throw new ValidationException("Crew member is on a  flight.It cannot  be fired now", "");
            }
            member.isNotWorking = true;
            _unitOfWork.Complete();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}