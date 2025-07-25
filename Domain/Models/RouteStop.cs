using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RouteStop : BaseEntity
    {
        public int RouteId { get; set; }
        public Route Route { get; set; }

        public int StopId { get; set; }
        public BusStop BusStop { get; set; }

        public int StopOrder { get; set; }
    }
}
