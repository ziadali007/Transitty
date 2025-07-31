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
    public class ScheduleService(IMapper mapper,IUnitOfWork unitOfWork) : IScheduleService
    {
        public async Task<IEnumerable<ScheduleResultDto>> GetAllScheduleAsync()
        {
            var Schedules= await unitOfWork.GetRepository<Schedule>().GetAllAsync();
            var result = mapper.Map<IEnumerable<ScheduleResultDto>>(Schedules);
            return result;
        }

        public async Task<ScheduleResultByIdDto?> GetScheduleByIdAsync(int id)
        {
            var Schedule= await unitOfWork.GetRepository<Schedule>().GetByIdAsync(id);
            if (Schedule is null) throw new ScheduleNotFoundException("Schedule Not Found Or Not Available");
            var result = mapper.Map<ScheduleResultByIdDto>(Schedule);
            return result;
        }

        public async Task AddScheduleAsync(ScheduleResultByIdDto Schedule)
        {
            var scheduleMap= mapper.Map<Schedule>(Schedule);
            await unitOfWork.GetRepository<Schedule>().AddAsync(scheduleMap);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new AddingNewScheduleBadRequestException("Schedule Is Not Added");
        }
        public async Task UpdateSchedule(ScheduleResultByIdDto Schedule)
        {
            var scheduleMap = mapper.Map<Schedule>(Schedule);
            unitOfWork.GetRepository<Schedule>().Update(scheduleMap);
            var result =await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new ScheduleNotFoundException("Schedule Not Updated");
        }
        public async Task DeleteScheduleAsync(int ScheduleId)
        {
            var schedule =await unitOfWork.GetRepository<Schedule>().GetByIdAsync(ScheduleId);
            if (schedule is null) throw new ScheduleNotFoundException("Schedule Not Found Or Not Available");
            unitOfWork.GetRepository<Schedule>().Delete(schedule);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new ScheduleNotFoundException("Schedule Not Deleted");
        }

        public async Task<bool> ScheduleExistsAsync(Expression<Func<Schedule, bool>> predicate)
        {
            return await unitOfWork.GetRepository<Schedule>().ExistsAsync(predicate);
        }

    }
}
