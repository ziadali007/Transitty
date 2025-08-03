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
    public class RouteController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRoutes()
        {
            var routes =await serviceManager.RouteService.GetAllRoutesAsync();
            if(routes is null) return NotFound("No routes found.");
            return Ok(routes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRouteById(int id)
        {
            var route = await serviceManager.RouteService.GetRouteByIdAsync(id);
            if (route is null) return NotFound($"Route with ID {id} not found.");
            return Ok(route);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoute([FromBody]RouteResultByIdDto routeDto)
        {
            await serviceManager.RouteService.AddRouteAsync(routeDto);
            return Ok(routeDto);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateRoute(int id, [FromBody]RouteResultByIdDto routeDto)
        {
            if (id != routeDto.RouteId) return BadRequest();
            await serviceManager.RouteService.UpdateRoute(routeDto);
            return Ok(routeDto);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRoute(int id)
        {
            await serviceManager.RouteService.DeleteRouteAsync(id);
            return NoContent();
        }


    }
}
