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
    public class TicketProfile : Profile
    {
        public TicketProfile() 
        {
              CreateMap<Ticket,TicketResultDto>().ReverseMap();
        
        }
    }
}
