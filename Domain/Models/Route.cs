using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Route
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public string StartPoint { get; set; }


        public string EndPoint { get; set; }


        public IEnumerable<Bus> Buses { get; set; }

        public IEnumerable<BusStop> BusesStop { get; set; }


        public IEnumerable<Trip> Trips { get; set; }




    }
}
