using RegistrationService.Models;
using RegistrationService.Services;
using AuthenticationService.Models;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class AuthenticationController : ControllerBase
    {
        public readonly IUserInterface _iUserInterface;
        public readonly IJWTTokenInterface _iJWTTokenInterface;
        public AuthenticationController(IUserInterface iUserInterface, IJWTTokenInterface iJWTTokenInterface)
        {
            _iUserInterface = iUserInterface;
            _iJWTTokenInterface = iJWTTokenInterface;
        }

        public IActionResult AuthenticateUser(User userFromUI)
        {
            if(validUser(userFromUI))
            {
                User userFromDB = _iUserInterface.GetAllUsers().Where(a => a.UserName.ToLower() == userFromUI.UserName.ToLower() &&
                                                          a.Password.ToLower() == userFromUI.Password.ToLower()).ToList()[0];
                var token = _iJWTTokenInterface.GenerateToken(userFromDB);
                return Ok(token);
            }
            else
            {
                return Ok("Invalid Email or Password");
            }
        }

        private bool validUser(User user) 
        {
            return _iUserInterface.GetAllUsers().Any(a => a.UserName.ToLower() == user.UserName.ToLower() && 
                                                          a.Password.ToLower() == user.Password.ToLower());
        }
    }        
}