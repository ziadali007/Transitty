using AutoMapper;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<Route, RouteResultDto>().ReverseMap();

            CreateMap<Route, RouteResultByIdDto>().ReverseMap();

            CreateMap<Route, RouteBusStopResultByIdDto>()
                .ForMember(dest => dest.RouteStops, opt => opt.MapFrom(src =>
                src.RouteStops.OrderBy(rs => rs.StopOrder)));


        }
    }
}
