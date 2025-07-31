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
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip,TripResultDto>().ReverseMap();
            CreateMap<Trip, TripResultByIdDto>().ReverseMap();

        }
    }
}
