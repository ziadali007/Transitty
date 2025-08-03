using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class TripResultByIdDto
    {
        [Required]
        public int TripId { get; set; }
        [Required]
        public int BusId { get; set; }
        [Required]
        public int RouteId { get; set; }
        [Required]
        public int DriverId { get; set; }
        public int ConductorId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        



    }
}
