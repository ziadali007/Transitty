using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ScheduleResultByIdDto
    {
        public int ScheduleId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime StartShift { get; set; }

        public DateTime EndShift { get; set; }


        public bool IsOnLeave { get; set; }
    }
}
