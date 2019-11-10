using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.DTOs;

namespace AirlineApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Profession, ProfessionDto>();

            Mapper.CreateMap<FlightViewModel, Flight>().ForMember(c => c.Date, v => v.MapFrom(e => e.GetDateTime()))
                .ForMember(c => c.Code, v => v.MapFrom(e => e.Code))
                .ForMember(c => c.StatusId, v => v.MapFrom(e => e.StatusId));

            Mapper.CreateMap<FlightViewModel, Flight>().ForMember(c => c.Date, v => v.MapFrom(e => e.GetDateTime()))
                .ForMember(c => c.Code, v => v.MapFrom(e => e.Code))
                .ForMember(c => c.StatusId, v => v.MapFrom(e => e.StatusId))
                .ForMember(c => c.FlightId, v => v.MapFrom(e => e.FlightId));


            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Notification, NotificationDto>();

            Mapper.CreateMap<UserDto, ApplicationUser>();
            Mapper.CreateMap<NotificationDto, Notification>();

            Mapper.CreateMap<CrewMember, CrewMemberDto>();
            Mapper.CreateMap<CrewMemberDto, CrewMember>();
        }
    }
}