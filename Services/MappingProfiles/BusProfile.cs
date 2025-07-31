using AutoMapper;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transitty.Shared;

namespace Services.MappingProfiles
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<Bus,BusResultDto>().ReverseMap();

            CreateMap<Bus, BusResultByIdDto>().ReverseMap();
        }
    }
}
