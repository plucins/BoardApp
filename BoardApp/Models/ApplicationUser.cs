using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using BoardApp.Models.dto;
using BoardApp.Models.enums;
using Microsoft.AspNetCore.Identity;

namespace BoardApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole UserRole { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        
        

        public static ApplicationUser Create(RegisterUserDto registerUserDto)
        {
            
            return new ApplicationUser
            {
                UserEmail = registerUserDto.Email,
                UserPassword = registerUserDto.Password,
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                UserRole = UserRole.NONE,
            };
        }
    }
}