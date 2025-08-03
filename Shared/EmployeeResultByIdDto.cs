using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class EmployeeResultByIdDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [Length(5, 100)]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }
        [Required]
        [Length(11, 15)]
        public string ContactInfo { get; set; }

    }
}
