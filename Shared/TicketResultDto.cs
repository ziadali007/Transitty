using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class TicketResultDto
    {
        public int TripId { get; set; }
        public int SeatId { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookingTime { get; set; }


    }
}
