using AutoMapper;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using routeStop=Shared.RouteStopDto;
namespace Services.MappingProfiles
{
    public class RouteStopProfile : Profile
    {
        public RouteStopProfile()
        {
          
            CreateMap<RouteStop, routeStop>()
            .ForMember(dest => dest.StopId, opt => opt.MapFrom(src => src.StopId))
            .ForMember(dest => dest.StopName, opt => opt.MapFrom(src => src.BusStop.StopName))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.BusStop.Location))
            .ForMember(dest => dest.StopOrder, opt => opt.MapFrom(src => src.StopOrder));
        }
    }
}
