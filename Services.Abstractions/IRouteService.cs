using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services.Abstractions
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteResultDto>> GetAllRoutesAsync();

        Task<RouteResultByIdDto?> GetRouteByIdAsync(int id);

        Task AddRouteAsync(RouteResultByIdDto route);

        Task UpdateRoute(RouteResultByIdDto route);

        Task DeleteRouteAsync(int routeId);


        Task<bool> RouteExistsAsync(Expression<Func<Route, bool>> predicate);

    }
}
