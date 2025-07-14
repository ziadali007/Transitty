using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RouteStopTiming
    {
        public int RouteStopTimingId { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }


        public int StopId { get; set; }

        public BusStop BusStop { get; set; }


        public int BusId { get; set; }

        public Bus Bus { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
