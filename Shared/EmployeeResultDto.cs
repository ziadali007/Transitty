using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class EmployeeResultDto
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string ContactInfo { get; set; }
    }
}
