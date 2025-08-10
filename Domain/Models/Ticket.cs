using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket : BaseEntity
    {
        public int TicketId { get; set; }

        public int TripId { get; set; }

        public Trip Trip { get; set; }

        public int SeatId { get; set; }

        public Seat Seat { get; set; }

        public string CustomerName { get; set; }

        public DateTime BookingTime { get; set; }

        public string? ClientSecret { get; set; }

        public string? PaymentIntentId { get; set; }

        public decimal Price { get;set; }
    }
}
