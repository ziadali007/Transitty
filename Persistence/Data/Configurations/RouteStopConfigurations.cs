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

            builder.HasOne(rs => rs.Route)
                .WithMany(r => r.RouteStops)
                .HasForeignKey(rs => rs.RouteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rs => rs.BusStop)
                .WithMany(bs => bs.RouteStops)
                .HasForeignKey(rs => rs.StopId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
