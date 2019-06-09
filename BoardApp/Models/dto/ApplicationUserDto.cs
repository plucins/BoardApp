using System.Threading.Tasks;

namespace BoardApp.Models.dto
{
    public class ApplicationUserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }

        public static  ApplicationUserDto Create(ApplicationUser applicationUser)
        {
            return new ApplicationUserDto
            {
                
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.UserEmail,
            };
        }
        
        public static  ApplicationUserDto CreateWithToken(ApplicationUser applicationUser, string Token)
        {
            return new ApplicationUserDto
            {
                
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                Email = applicationUser.UserEmail,
                Token = Token
            };
        }
    }
}