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
    public class TripService(IMapper mapper,IUnitOfWork unitOfWork) : ITripService
    {
        public async Task<IEnumerable<TripResultDto>> GetAllTripsAsync()
        {
           var trips= await unitOfWork.GetRepository<Trip>().GetAllAsync();
            var result = mapper.Map<IEnumerable<TripResultDto>>(trips);
            return result;
        }

        public async Task<TripResultByIdDto?> GetTripByIdAsync(int id)
        {
            var trip =await unitOfWork.GetRepository<Trip>().GetByIdAsync(id);
            if (trip is null) throw new TripNotFoundException("Trip Not Found");
            var result = mapper.Map<TripResultByIdDto>(trip);
            return result;
        }
        public async Task AddTripAsync(TripResultByIdDto trip)
        {
            var newTrip= mapper.Map<Trip>(trip);
            await unitOfWork.GetRepository<Trip>().AddAsync(newTrip);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new AddingNewTripBadRequestException("Trip Is Not Added");
        }
        public async Task UpdateTrip(TripResultByIdDto trip)
        {
            var result = mapper.Map<Trip>(trip);
            unitOfWork.GetRepository<Trip>().Update(result);
            var resullt = unitOfWork.SaveChangesAsync();
            if (resullt.Result == 0) throw new TripNotFoundException("Trip Not Updated");
        }

        public async Task DeleteTripAsync(int tripId)
        {
            var trip =await unitOfWork.GetRepository<Trip>().GetByIdAsync(tripId);
            if (trip is null) throw new TripNotFoundException("Trip Not Found Or Not Available");
            unitOfWork.GetRepository<Trip>().Delete(trip);
            var result = await unitOfWork.SaveChangesAsync();
            if (result == 0) throw new TripNotFoundException("Trip Is Not Deleted");
        }

        public async Task<bool> TripExistsAsync(Expression<Func<Trip, bool>> predicate)
        {
            return await unitOfWork.GetRepository<Trip>().ExistsAsync(predicate);
        }

        public async Task<IEnumerable<SeatResultDto>> GetAvailableSeatsAsync(int tripId)
        {
            var trip=await unitOfWork.GetRepository<Trip>().GetByIdAsync(tripId);
            if (trip is null) throw new TripNotFoundException("Trip Not Found Or Not Available");
            var bus= await unitOfWork.GetRepository<Bus>().GetByIdAsync(trip.BusId);
            if (bus is null) throw new BusNotFoundException("Bus Not Found Or Not Available");
            var seats = await unitOfWork.GetRepository<Seat>().FindAsync(s => s.BusId == bus.BusId);

            var bookedSeats =(await unitOfWork.GetRepository<Ticket>().FindAsync(t=>t.TripId == tripId))
                               .Select(t => t.SeatId)
                               .ToList();

            var availableSeats = seats.Where(s => !bookedSeats.Contains(s.SeatId)).ToList();

            var result = mapper.Map<IEnumerable<SeatResultDto>>(availableSeats);

            return result;

        }

        public async Task<TicketResultDto> BookSeatAsync(int tripId, int seatId, string customerName)
        {
            var trip=await unitOfWork.GetRepository<Trip>().GetByIdAsync(tripId);
            if (trip is null) throw new TripNotFoundException("Trip Not Found");

            var seat = await unitOfWork.GetRepository<Seat>().GetByIdAsync(seatId);
            if (seat is null) throw new SeatAlreadyBookedException("Seat Not Found Or Not Available");

            bool isAlreadyBooked= await unitOfWork.GetRepository<Ticket>().ExistsAsync(t => t.TripId == tripId && t.SeatId == seatId);

            if (isAlreadyBooked) throw new SeatAlreadyBookedException("Seat Is Already Booked");

            var ticket = new TicketResultDto
            {
                TripId = tripId,
                SeatId = seatId,
                CustomerName = customerName,
                BookingTime = DateTime.UtcNow
            };

            await unitOfWork.GetRepository<Ticket>().AddAsync(mapper.Map<Ticket>(ticket));

            var result = await unitOfWork.SaveChangesAsync();

            if (result == 0) throw new BookingSeatBadRequestException("Seat Booking Failed");

            return ticket;

        }
    }
}
