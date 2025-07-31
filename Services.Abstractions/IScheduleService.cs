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
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleResultDto>> GetAllScheduleAsync();

        Task<ScheduleResultByIdDto?> GetScheduleByIdAsync(int id);

        Task AddScheduleAsync(ScheduleResultByIdDto Schedule);

        Task UpdateSchedule(ScheduleResultByIdDto Schedule);

        Task DeleteScheduleAsync(int ScheduleId);

        Task<bool> ScheduleExistsAsync(Expression<Func<Schedule, bool>> predicate);
    }
}
