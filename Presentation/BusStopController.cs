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
    public class BusStopController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBusStops()
        {
            var busStops = await serviceManager.BusStopService.GetAllBusStopsAsync();
            if (busStops is null) return NotFound("No bus stops found.");
            return Ok(busStops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusStopById(int id)
        {
            var busStop = await serviceManager.BusStopService.GetBusStopByIdAsync(id);
            if (busStop is null) return NotFound($"Bus stop with ID {id} not found.");
            return Ok(busStop);
        }

        [HttpPost]
        public async Task<IActionResult> AddBusStop([FromBody] AddBusStopToRouteDto busStopDto)
        {
            if (busStopDto is null) return BadRequest("Bus stop data is null");
            await serviceManager.BusStopService.AddBusStopAsync(busStopDto);
            return Ok(busStopDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusStop(int id, [FromBody] BusStopResultByIdDto busStopDto)
        {
            if (id != busStopDto.StopId) return BadRequest("Bus stop ID mismatch");
            await serviceManager.BusStopService.UpdateBusStop(busStopDto);
            return Ok(busStopDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusStop(int id)
        {
            await serviceManager.BusStopService.DeleteBusStopAsync(id);
            return NoContent();
        }
    }
}
