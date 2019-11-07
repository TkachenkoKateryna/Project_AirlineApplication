using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineApplication.Core;
using AirlineApplication.Core.DTOs;
using AirlineApplication.Core.Models;
using AutoMapper;

namespace AirlineApplication.Controllers.Api
{
    public class CrewMembersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrewMembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET / api/crewmemebers
        public IEnumerable<CrewMemberDto> GetCrewMembers()
        {
            return _unitOfWork.CrewMembers.GetAllCrewMembers().Select(Mapper.Map<CrewMember, CrewMemberDto>);
        }

        // GET / api/crewmemebers/1
        [HttpGet]
        public IHttpActionResult GetCrewMember(int crewMemberId)
        {
            var member = _unitOfWork.CrewMembers.GetCrewMember(crewMemberId);
            if (member == null)
                return NotFound();

            return Ok(Mapper.Map<CrewMember, CrewMemberDto>(member));
        }

        // Post / api/crewmemebers
        [HttpPost]
        public IHttpActionResult CreateCrewMember(CrewMemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var member = Mapper.Map<CrewMemberDto, CrewMember>(memberDto);
            _unitOfWork.CrewMembers.CreateCrewMember(member);
            _unitOfWork.Complete();

            memberDto.CrewMemberId = member.CrewMemberId;
            return Created(new Uri(Request.RequestUri + "/" + member.CrewMemberId), memberDto);
        }

        //Put /api/crewmembers/1
        [HttpPut]
        public IHttpActionResult UpdateCrewMember(int id, CrewMemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var memberInDb = _unitOfWork.CrewMembers.GetCrewMember(id);
            if (memberInDb == null)
                return NotFound();

            Mapper.Map(memberDto, memberInDb);

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var member = _unitOfWork.CrewMembers.GetCrewMember(id);
            member.isNotWorking = true;
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
