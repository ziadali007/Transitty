using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transitty.Shared;

namespace Services.Abstractions
{
    public interface IBusService
    {
        Task<IEnumerable<BusResultDto>> GetAllBusesAsync();

        Task<BusResultByIdDto?> GetBusByIdAsync(int id);

        Task AddBusAsync(BusResultByIdDto bus);

        Task UpdateBus(BusResultByIdDto bus);

        Task DeleteBusAsync(int busId);


        Task<bool> BusExistsAsync(Expression<Func<Bus, bool>> predicate);
    }
}
