using Domain.Exceptions;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthService(UserManager<AppUser> userManager,IOptions<JwtOptions> options) : IAuthService
    {
       
        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if(user is null) throw new UnAuthorizedException();

            var isPasswordValid = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid) throw new UnAuthorizedException();

            return new UserResultDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await GenerateJwtToken(user)
            };
        }

        public async Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
        {
            var DuplicatedUserName = await userManager.FindByNameAsync(registerDto.UserName);
            if (DuplicatedUserName is not null) throw new DuplicationException("UserName Is Already Exist");
            if (await CheckEmailExistAsync(registerDto.Email)) throw new DuplicationException("Email Is Already Exist");
            var user = new AppUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,                
                PhoneNumber = registerDto.PhoneNumber
            };
            var result= await userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new ValidationException(errors);
            }
            return new UserResultDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await GenerateJwtToken(user)
            };
           
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            var user=await userManager.FindByEmailAsync(email);
            return user is not null;
        }

        public async Task<UserResultDto> GetCurrentUserAsync(string email)
        {
            var user= await userManager.FindByEmailAsync(email);
            if (user is null) throw new UserNotFoundException("User Not Found");

            return new UserResultDto()
            {
                UserName=user.UserName,
                Email=user.Email,               
                Token=await GenerateJwtToken(user)
            };
        }
        public async Task<string> GenerateJwtToken(AppUser user)
        {
            var jwtOptions= options.Value;
            var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles= await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, role));
            }

            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

            var token= new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: authClaim,
                expires: DateTime.Now.AddDays(jwtOptions.DurationInDays),
                signingCredentials: new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
