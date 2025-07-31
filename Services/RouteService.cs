using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RouteService(IMapper mapper,IUnitOfWork unitOfWork) : IRouteService
    {
        public async Task<IEnumerable<RouteResultDto>> GetAllRoutesAsync()
        {
            var routes= await unitOfWork.GetRepository<Route>().GetAllAsync();
            var result = mapper.Map<IEnumerable<RouteResultDto>>(routes);
            return result;

        }

        public async Task<RouteResultByIdDto?> GetRouteByIdAsync(int id)
        {
            var route =await unitOfWork.GetRepository<Route>().GetByIdAsync(id);
            if (route is null) throw new RouteNotFoundException("Route Not Found Or Not Available");

            var result = mapper.Map<RouteResultByIdDto>(route);
            return result;

        }
        public async Task AddRouteAsync(RouteResultByIdDto route)
        {

            var newRoute= mapper.Map<Route>(route);

            await unitOfWork.GetRepository<Route>().AddAsync(newRoute);

            var result = await unitOfWork.SaveChangesAsync();

            if (result == 0) throw new AddingNewRouteBadRequestException("Route Is Not Added");

        }

        public async Task UpdateRoute(RouteResultByIdDto route)
        {
            var result = mapper.Map<Route>(route);
            unitOfWork.GetRepository<Route>().Update(result);
            var resullt = await unitOfWork.SaveChangesAsync();
            if (resullt == 0) throw new RouteNotFoundException("Route Not Updated");
        }

        public async Task DeleteRouteAsync(int routeId)
        {
            var route= await unitOfWork.GetRepository<Route>().GetByIdAsync(routeId);
            if (route is null) throw new RouteNotFoundException("Route Not Found Or Not Available");

            unitOfWork.GetRepository<Route>().Delete(route);
            var resullt = await unitOfWork.SaveChangesAsync();
            if (resullt == 0) throw new RouteNotFoundException("Route Not Deleted");
        }

       
        public async Task<bool> RouteExistsAsync(Expression<Func<Route, bool>> predicate)
        {
            return await unitOfWork.GetRepository<Route>().ExistsAsync(predicate);
        }

       
    }
}
