using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await serviceManager.AuthService.LoginAsync(loginDto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await serviceManager.AuthService.RegisterAsync(registerDto);
            return Ok(result);
        }

        [HttpGet("checkEmail")]

        public async Task<IActionResult> CheckEmailExist([FromQuery] string email)
        {
            var isExist = await serviceManager.AuthService.CheckEmailExistAsync(email);
            return Ok(isExist);
        }

        [HttpGet("getCurrentUser")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }
            var user = await serviceManager.AuthService.GetCurrentUserAsync(email);
            return Ok(user);
        }
    }
}
