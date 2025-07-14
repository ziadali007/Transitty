using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bus
    {
        public int BusId { get; set; }

        public string BusNumber { get; set; }

        public string BusName { get; set; }

        public int Capacity { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }


        public IEnumerable<Trip> Trips { get; set; }


        public IEnumerable<RouteStopTiming> StopTimings { get; set; }
    }
}
