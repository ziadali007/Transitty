using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Persistence;
using Domain.Models.Identity;
namespace Presistence.Data
{
    public class TransityDbContext : DbContext
    {
        public TransityDbContext(DbContextOptions<TransityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRef).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Bus> Buses { get; set; }

        public DbSet<RouteStopTiming> RouteStopTimings { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
