using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Seat
    {
        public int SeatId { get; set; }

        public int BusId { get; set; }

        public Bus Bus { get; set; }

        public String SeatNumber { get; set; }

        public bool IsWindow {  get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
