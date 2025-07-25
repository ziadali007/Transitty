using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum EmployeeRole
    {
        Driver,
        Conductor,
        Admin,
        Staff
    }
    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public EmployeeRole EmployeeRole { get; set; }

        public string ContactInfo { get; set; }

        public IEnumerable<Schedule> Schedules { get; set; }
        public IEnumerable<Trip> TripsAsDriver { get; set; }
        public IEnumerable<Trip> TripsAsConductor { get; set; }
    }
}
