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
using Transitty.Shared;

namespace Services
{
    public class BusService(IMapper mapper,IUnitOfWork unitOfWork) : IBusService
    {
        public async Task<IEnumerable<BusResultDto>> GetAllBusesAsync()
        {
            var buses = await unitOfWork.GetRepository<Bus>().GetAllAsync();
            var result = mapper.Map<IEnumerable<BusResultDto>>(buses);
            return result;
        }

        public async Task<BusResultByIdDto?> GetBusByIdAsync(int id)
        {
            var bus = await unitOfWork.GetRepository<Bus>().GetByIdAsync(id);
            if (bus is null) throw new BusNotFoundException("Bus Not Found Or Not Available");
            var result = mapper.Map<BusResultByIdDto>(bus);
            return result;
        }

        public async Task AddBusAsync(BusResultByIdDto bus)
        {
            var route = await unitOfWork.GetRepository<Route>().GetByIdAsync(bus.RouteId);
            if (route is null) throw new RouteNotFoundException("Route Not Found");


            if (bus.Seats.Count() > bus.Capacity) throw new SeatsExceedsBusCapacityException("Number of seats exceeds bus capacity.");

            var newBus = mapper.Map<Bus>(bus);
            await unitOfWork.GetRepository<Bus>().AddAsync(newBus);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new AddingNewBusBadRequestException("Bus Is Not Added");

            foreach (var seatDto in bus.Seats)
            {
                var seat = mapper.Map<Seat>(seatDto);
                seat.BusId=newBus.BusId;
                await unitOfWork.GetRepository<Seat>().AddAsync(seat);
            }
            
            var result2 = await unitOfWork.SaveChangesAsync();
            if (result2 == 0) throw new AddingNewBusBadRequestException("Seats Are Not Added");

        }

        public async Task UpdateBus(BusResultByIdDto bus)
        {
            var route = await unitOfWork.GetRepository<Route>().GetByIdAsync(bus.RouteId);
            if (route is null) throw new RouteNotFoundException("Route Not Found");
            var result = mapper.Map<Bus>(bus);
            unitOfWork.GetRepository<Bus>().Update(result);
            var resullt=await unitOfWork.SaveChangesAsync();
            if (resullt == 0) throw new BusNotFoundException("Bus Not Updated");

            foreach (var seatDto in bus.Seats)
            {
                var seat = mapper.Map<Seat>(seatDto);
                seat.BusId = bus.BusId;
                await unitOfWork.GetRepository<Seat>().AddAsync(seat);
            }

            var result2 = await unitOfWork.SaveChangesAsync();
            if (result2 == 0) throw new AddingNewBusBadRequestException("Seats Are Not Added");
        }

        public async Task DeleteBusAsync(int busId)
        {
            var bus =await unitOfWork.GetRepository<Bus>().GetByIdAsync(busId);
            if (bus is null) throw new BusNotFoundException("Bus Not Found Or Not Available");
            unitOfWork.GetRepository<Bus>().Delete(bus);
            var resullt = await unitOfWork.SaveChangesAsync();
            if (resullt == 0) throw new BusNotFoundException("Bus Not Deleted");
        }
        public async Task<bool> BusExistsAsync(Expression<Func<Bus, bool>> predicate)
        {
            return await unitOfWork.GetRepository<Bus>().ExistsAsync(predicate);
        }
    }
}
