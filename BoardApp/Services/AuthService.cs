using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BoardApp.Models;
using BoardApp.Models.dto;
using BoardApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BoardApp.Services
{
    public class AuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ApplicationUserDto> RegisterUser(RegisterUserDto registerUserDto)
        {
            if (_authRepository.GetByEmail(registerUserDto.Email).Result != null)
            {
                return new ApplicationUserDto();
            }
            
           return ApplicationUserDto.Create(await _authRepository.Add(ApplicationUser.Create(registerUserDto)));
        }

        public async Task<ApplicationUserDto> LoginUser(LoginUserDto user)
        {
            var applicationUser = await _authRepository.GetByEmail(user.Email);
            
            if (applicationUser != null)
            {
                return ApplicationUserDto.CreateWithToken(applicationUser, GenerateToken(applicationUser));
            }
            
            return new ApplicationUserDto();
        }

        private string GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
          
            
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyUltraSuperSecureKey"));
            
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}