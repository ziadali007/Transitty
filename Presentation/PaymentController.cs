using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost("{tripId}")]
        [Authorize]
        public async Task<IActionResult> CreateOrUpdatePaymentIntent(int tripId)
        {
           var result =await serviceManager.PaymentService.CreateOrUpdatePaymentIntentAsync(tripId);
            return Ok(result);
        }
    }
}
