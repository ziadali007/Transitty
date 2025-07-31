using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BusStopResultByIdDto
    {
        public int StopId { get; set; }

        public string StopName { get; set; }

        public string Location { get; set; }


        public IEnumerable<RouteStop>? RouteStops { get; set; }

        public IEnumerable<RouteStopTiming>? RouteStopsTimings { get; set; }
    }
}
