using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IRouteService RouteService { get; }

        IBusService BusService { get; }

        ITripService TripService { get; }

        IEmployeeService EmployeeService { get; }

        IBusStopService BusStopService { get; }

        IScheduleService ScheduleService { get; }

        IAuthService AuthService { get; }
    }
}
