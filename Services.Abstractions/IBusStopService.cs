using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IBusStopService
    {
        Task<IEnumerable<BusStopResultDto>> GetAllBusStopsAsync();

        Task<BusStopResultByIdDto?> GetBusStopByIdAsync(int id);

        Task AddBusStopAsync(BusStopResultByIdDto BusStop);

        Task UpdateBusStop(BusStopResultByIdDto BusStop);

        Task DeleteBusStopAsync(int BusStopId);


        Task<bool> BusStopExistsAsync(Expression<Func<BusStop, bool>> predicate);
    }
}
