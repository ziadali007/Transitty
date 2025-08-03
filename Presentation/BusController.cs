using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transitty.Shared;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBuses()
        {
            var buses=await serviceManager.BusService.GetAllBusesAsync();
            if(buses is null) return NotFound();
            return Ok(buses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusById(int id)
        {
            var bus = await serviceManager.BusService.GetBusByIdAsync(id);
            if (bus is null) return NotFound();
            return Ok(bus);
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] BusResultByIdDto busDto)
        {
            if (busDto is null) return BadRequest("Bus data is null");
            await serviceManager.BusService.AddBusAsync(busDto);
            return Ok(busDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBus(int id, [FromBody] BusResultByIdDto busDto)
        {
            if (id != busDto.BusId) return BadRequest("Bus ID mismatch");
            await serviceManager.BusService.UpdateBus(busDto);
            return Ok(busDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {
            await serviceManager.BusService.DeleteBusAsync(id);
            return NoContent();
        }
    }
}
