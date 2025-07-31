using AutoMapper;
using Domain.Contracts;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager(IMapper mapper,IUnitOfWork unitOfWork) : IServiceManager
    {
       
        public IRouteService RouteService { get; } = new RouteService(mapper, unitOfWork);

        public IBusService BusService { get; } = new BusService(mapper, unitOfWork);

        public ITripService TripService {get; } = new TripService(mapper, unitOfWork);

        public IEmployeeService EmployeeService { get; } = new EmployeeService(mapper, unitOfWork);

        public IBusStopService BusStopService { get; } = new BusStopService(mapper, unitOfWork);

        public IScheduleService ScheduleService { get; } = new ScheduleService(mapper, unitOfWork);
    }
}
