using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Services.Abstractions;
using Shared;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService(IUnitOfWork unitOfWork,IMapper mapper,IConfiguration configuration) : IPaymentService
    {
        public async Task<TicketResultDto> CreateOrUpdatePaymentIntentAsync(int tripId)
        {
            var trip = await unitOfWork.GetRepository<Trip>().GetByIdAsync(tripId);

            if (trip is null) throw new TripNotFoundException("Trip Not Found");

            var ticket = await unitOfWork.GetRepository<Ticket>().GetByIdAsync(tripId);

            var amount = (long)(trip.TicketPrice * 100);

            StripeConfiguration.ApiKey = configuration["StripeSettings:SecretKey"];

            var services = new PaymentIntentService();

            if (string.IsNullOrEmpty(ticket.PaymentIntentId))
            {
                var createOptions = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = new List<string> { "card" },

                };

                var paymentIntent = await services.CreateAsync(createOptions);
                ticket.PaymentIntentId = paymentIntent.Id;
                ticket.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var updateOptions = new PaymentIntentUpdateOptions
                {
                    Amount = amount,
                };
                await services.UpdateAsync(ticket.PaymentIntentId, updateOptions);

            }

            var result = mapper.Map<TicketResultDto>(ticket);

            return result;
        }
    }
}
