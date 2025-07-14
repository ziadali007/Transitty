using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configurations
{
    public class RouteStopConfigurations : IEntityTypeConfiguration<RouteStop>
    {
       
        public void Configure(EntityTypeBuilder<RouteStop> builder)
        {

            builder.HasKey(rs => new { rs.RouteId, rs.StopId });
        }
    }
}
