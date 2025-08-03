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
    public interface ITripService
    {
        Task<IEnumerable<TripResultDto>> GetAllTripsAsync();
        Task<TripResultByIdDto?> GetTripByIdAsync(int id);
        Task AddTripAsync(TripResultByIdDto trip);
        Task UpdateTrip(TripResultByIdDto trip);
        Task DeleteTripAsync(int tripId);
        Task<bool> TripExistsAsync(Expression<Func<Trip, bool>> predicate);

        Task<IEnumerable<SeatResultDto>> GetAvailableSeatsAsync(int tripId);

        Task<TicketResultDto> BookSeatAsync(int tripId, int seatId, string seatNumber, string customerName);
    }
}
