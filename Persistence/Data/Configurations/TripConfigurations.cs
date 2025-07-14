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
    public class TripConfigurations : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasOne(t=>t.Driver)
                .WithMany(e=>e.TripsAsDriver)
                .HasForeignKey(t => t.DriverId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(t => t.Conductor)
                .WithMany(e => e.TripsAsConductor)
                .HasForeignKey(t => t.ConductorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(t => t.Bus)
                .WithMany(b => b.Trips)
                .HasForeignKey(t => t.BusId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(t => t.Route)
                .WithMany(r => r.Trips)
                .HasForeignKey(t => t.RouteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
