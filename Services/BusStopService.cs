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
    public class BusStopService(IMapper mapper,IUnitOfWork unitOfWork) : IBusStopService
    {
        public async Task<IEnumerable<BusStopResultDto>> GetAllBusStopsAsync()
        {
            var busStops= await unitOfWork.GetRepository<BusStop>().GetAllAsync();
            var result= mapper.Map<IEnumerable<BusStopResultDto>>(busStops);
            return result;
        }

        public async Task<BusStopResultByIdDto?> GetBusStopByIdAsync(int id)
        {
            var busStop=await unitOfWork.GetRepository<BusStop>().GetByIdAsync(id);
            if (busStop is null) throw new BusNotFoundException("BusStop Not Found");
            var result = mapper.Map<BusStopResultByIdDto>(busStop);
            return result;
        }
        public async Task AddBusStopAsync(BusStopResultByIdDto BusStop)
        {
            var busStop = mapper.Map<BusStop>(BusStop);
            await unitOfWork.GetRepository<BusStop>().AddAsync(busStop);
            var result= await unitOfWork.SaveChangesAsync();
            if(result == 0) throw new AddingNewBusStopBadRequestException("Bus Is Not Added");
        }
        public async Task UpdateBusStop(BusStopResultByIdDto BusStop)
        {
            var busStop=mapper.Map<BusStop>(BusStop);
            unitOfWork.GetRepository<BusStop>().Update(busStop);
            int result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new AddingNewBusStopBadRequestException("Bus Is Not Updated");
        }

        public async Task DeleteBusStopAsync(int BusStopId)
        {
            var busStop=await unitOfWork.GetRepository<BusStop>().GetByIdAsync(BusStopId);
            if(busStop is null) throw new BusNotFoundException("BusStop Not Found");
            unitOfWork.GetRepository<BusStop>().Delete(busStop);
            var result= await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new BusNotDeletedException("BusStop Is Not Deleted");

        }
        public async Task<bool> BusStopExistsAsync(Expression<Func<BusStop, bool>> predicate)
        {
            return await unitOfWork.GetRepository<BusStop>().ExistsAsync(predicate);
        }

    }
}
