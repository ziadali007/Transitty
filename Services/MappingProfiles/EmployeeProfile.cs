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
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {

            CreateMap<Employee, EmployeeResultDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.EmployeeRole.ToString()));

            CreateMap<EmployeeResultDto, Employee>()
                .ForMember(dest => dest.EmployeeRole, opt => opt.MapFrom(src => Enum.Parse<EmployeeRole>(src.Role)));
        }
    }
}
