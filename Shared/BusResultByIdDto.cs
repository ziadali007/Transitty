using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRoute = Domain.Models.Route;

namespace Shared
{
    public class BusResultByIdDto
    {
        [Required]
        public int BusId { get; set; }

        public string BusNumber { get; set; }
        [Length(5, 100)]
        public string BusName { get; set; }
        [Required]
        public int Capacity { get; set; }
        public int RouteId { get; set; }

        public IEnumerable<SeatResultDto> Seats { get; set; }

    }
}
