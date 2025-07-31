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
    public class BusStopProfile : Profile
    {
        public BusStopProfile() 
        {


            CreateMap<BusStop,BusStopResultDto>().ReverseMap();

            CreateMap<BusStop,BusResultByIdDto>().ReverseMap();
        
        
        }
    }
}
