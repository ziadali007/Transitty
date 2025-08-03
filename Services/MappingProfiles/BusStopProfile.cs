using AutoMapper;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using busStop = Shared.RouteStopDto;

namespace Services.MappingProfiles
{
    public class BusStopProfile : Profile
    {
        public BusStopProfile() 
        {


            CreateMap<BusStop,BusStopResultDto>().ReverseMap();

            CreateMap<BusStop,BusStopResultByIdDto>().ReverseMap();

            CreateMap<busStop, BusStop>().ReverseMap();

            CreateMap<AddBusStopToRouteDto, BusStop>()
            .ForMember(dest => dest.StopId, opt => opt.Ignore());

            CreateMap<(int stopId, AddBusStopToRouteDto dto), RouteStop>()
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.dto.RouteId))
                .ForMember(dest => dest.StopId, opt => opt.MapFrom(src => src.stopId))
                .ForMember(dest => dest.StopOrder, opt => opt.MapFrom(src => src.dto.StopOrder));




        }
    }
}
