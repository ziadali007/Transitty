using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RouteBusStopResultByIdDto
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

        public IEnumerable<RouteStopDto> RouteStops { get; set; }
    }
}
