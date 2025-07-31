using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class SeatResultDto
    {
        public int SeatId { get; set; }
        public int BusId { get; set; }
        public String SeatNumber { get; set; }
        public bool IsWindow { get; set; }
    }
}
