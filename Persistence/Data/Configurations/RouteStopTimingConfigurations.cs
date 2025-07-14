using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configurations
{
    public class RouteStopTimingConfigurations : IEntityTypeConfiguration<RouteStopTiming>
    {
        public void Configure(EntityTypeBuilder<RouteStopTiming> builder)
        {
            builder.HasOne(rst=>rst.Route)
                .WithMany()
                 .HasForeignKey(rst => rst.RouteId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rst => rst.BusStop)
                .WithMany(bs=>bs.RouteStopsTimings)
                 .HasForeignKey(rst => rst.StopId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rst => rst.Bus)
                .WithMany(s=>s.StopTimings)
                .HasForeignKey(rst => rst.BusId)
                 .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
