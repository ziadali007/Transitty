using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTrips()
        {
            var trips = await serviceManager.TripService.GetAllTripsAsync();
            if (trips is null) return NotFound("No trips found.");
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripById(int id)
        {
            var trip = await serviceManager.TripService.GetTripByIdAsync(id);
            if (trip is null) return NotFound($"Trip with ID {id} not found.");
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrip([FromBody] TripResultByIdDto tripDto)
        {
            if (tripDto is null) return BadRequest("Trip data is null");
            await serviceManager.TripService.AddTripAsync(tripDto);
            return Ok(tripDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(int id, [FromBody] TripResultByIdDto tripDto)
        {
            if (id != tripDto.TripId) return BadRequest("Trip ID mismatch");
            await serviceManager.TripService.UpdateTrip(tripDto);
            return Ok(tripDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            await serviceManager.TripService.DeleteTripAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/AvailableSeats")]
        public async Task<IActionResult> GetAvailableSeats(int id)
        {
            var availableSeats = await serviceManager.TripService.GetAvailableSeatsAsync(id);
            if (availableSeats is null) return NotFound($"Trip with ID {id} not found or has no available seats.");
            return Ok(availableSeats);

        }

        [HttpPost("{id}/BookSeat")]
        public async Task<IActionResult> BookSeat(int id, [FromBody] TicketResultDto booking)
        {
            if (booking is null) return BadRequest("Seat data is null");
            var result = await serviceManager.TripService.BookSeatAsync(booking.TripId, booking.SeatId,booking.SeatNumber,booking.CustomerName);
            if (result is null) return BadRequest($"Failed to book seat for trip with ID {id}.");
            return Ok(booking);
        }
    }
}
