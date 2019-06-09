using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BoardApp.Models;
using BoardApp.Models.dto;
using BoardApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BoardApp.Controllers
{
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private AuthService _authService;


        
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto user)
        {
            var applicationUserDto = await _authService.LoginUser(user);

            if (applicationUserDto.Token != null)
            {
                return Ok(applicationUserDto);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            var user = await _authService.RegisterUser(registerUserDto);
            if (user.Email != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }

    }
}