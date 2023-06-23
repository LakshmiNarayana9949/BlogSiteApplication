using AuthenticationService.Models;
using RegistrationService.Models;
namespace AuthenticationService.Services
{
    public interface IJWTTokenInterface
    {
        public Token GenerateToken(User user);
    }
}
