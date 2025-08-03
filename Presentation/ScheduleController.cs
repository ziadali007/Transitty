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
    public class ScheduleController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await serviceManager.ScheduleService.GetAllScheduleAsync();
            if (schedules is null) return NotFound("No schedules found.");
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var schedule = await serviceManager.ScheduleService.GetScheduleByIdAsync(id);
            if (schedule is null) return NotFound($"Schedule with ID {id} not found.");
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule([FromBody] ScheduleResultByIdDto scheduleDto)
        {
            if (scheduleDto is null) return BadRequest("Schedule data is null");
            await serviceManager.ScheduleService.AddScheduleAsync(scheduleDto);
            return Ok(scheduleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] ScheduleResultByIdDto scheduleDto)
        {
            if (id != scheduleDto.ScheduleId) return BadRequest("Schedule ID mismatch");
            await serviceManager.ScheduleService.UpdateSchedule(scheduleDto);
            return Ok(scheduleDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await serviceManager.ScheduleService.DeleteScheduleAsync(id);
            return NoContent();
        }
    }
}
