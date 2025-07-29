using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Route : BaseEntity
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public string StartPoint { get; set; }


        public string EndPoint { get; set; }


        public ICollection<Bus> Buses { get; set; }
        public ICollection<RouteStop> RouteStops { get; set; }
        public ICollection<Trip> Trips { get; set; }




    }
}
