using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BusStopResultByIdDto
    {
        [Required]
        public int StopId { get; set; }
        [Length(5, 30)]
        public string StopName { get; set; }
        [Required]
        public string Location { get; set; }

    }
}
