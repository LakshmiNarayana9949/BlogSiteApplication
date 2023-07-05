using RegistrationService.Models;
using AuthenticationService.Models;
namespace AuthenticationService.Services
{
    public interface IJWTTokenInterface
    {
        public Token GenerateToken(User user);        
    }
}
