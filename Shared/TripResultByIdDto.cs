using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class TripResultByIdDto
    {
        public int TripId { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public int DriverId { get; set; }
        public int ConductorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public IEnumerable<Ticket>? Tickets { get; set; }


    }
}
