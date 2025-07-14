using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        public int BusId { get; set; }
        public Bus Bus { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public int DriverId { get; set; }
        public Employee Driver { get; set; }

        public int ConductorId { get; set; }
        public Employee Conductor { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
