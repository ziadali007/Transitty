using AutoMapper;
using Domain.Contracts;
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
        public Task<IEnumerable<RouteResultDto>> GetAllRoutesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RouteResultByIdDto>> GetRouteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task AddRouteAsync(RouteResultByIdDto route)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoute(RouteResultByIdDto route)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoute(int routeId)
        {
            throw new NotImplementedException();
        }

       
        public Task<bool> RouteExistsAsync(Expression<Func<Route, bool>> predicate)
        {
            throw new NotImplementedException();
        }

       
    }
}
