using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ScheduleResultByIdDto
    {
        [Required]
        public int ScheduleId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime StartShift { get; set; }
        [Required]
        public DateTime EndShift { get; set; }

        public bool IsOnLeave { get; set; }
    }
}
