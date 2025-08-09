using Domain.Models.Identity;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IAuthService
    {
        Task<UserResultDto> LoginAsync(LoginDto loginDto);

        Task<UserResultDto> RegisterAsync(RegisterDto registerDto);

        Task<string> GenerateJwtToken(AppUser user);

        Task<bool> CheckEmailExistAsync(string email);


        Task<UserResultDto> GetCurrentUserAsync(string email);
    }
}
