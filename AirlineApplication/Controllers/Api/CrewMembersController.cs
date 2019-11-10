using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineApplication.Core.Services;
using AirlineApplication.Core.DTOs;
using AirlineApplication.Core.Models;
using AutoMapper;

namespace AirlineApplication.Controllers.Api
{
    public class CrewMembersController : ApiController
    {
        private readonly ICrewMemberService _service;

        public CrewMembersController(ICrewMemberService service)
        {
            _service = service;
        }

        // GET / api/crewmemebers
        public IEnumerable<CrewMemberDto> GetCrewMembers()
        {
            return _service.GetCrewMembers();
        }

        // GET / api/crewmemebers/1
        [HttpGet]
        public IHttpActionResult GetCrewMember(int crewMemberId)
        {
            return Ok(_service.GetCrewMember(crewMemberId));
        }

        // Post / api/crewmemebers
        [HttpPost]
        public IHttpActionResult CreateCrewMember(CrewMemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var member = Mapper.Map<CrewMemberDto, CrewMember>(memberDto);
            _service.CreateCrewMember(member);

            memberDto.CrewMemberId = member.CrewMemberId;
            return Created(new Uri(Request.RequestUri + "/" + member.CrewMemberId), memberDto);
        }

        //Put /api/crewmembers/1
        [HttpPut]
        public IHttpActionResult UpdateCrewMember(int id, CrewMemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _service.UpdateCrewMember(id, memberDto);

            return Ok();
        }

        //Delete /api/cremembers
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);

            return Ok();
        }
    }
}
