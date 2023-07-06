using RegistrationService.Models;
using AuthenticationService.Models;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class AuthenticationController : ControllerBase
    {
        public readonly IJWTTokenInterface _iJWTTokenInterface;
        public AuthenticationController(IJWTTokenInterface iJWTTokenInterface)
        {
            _iJWTTokenInterface = iJWTTokenInterface;
        }
        [Route("Authenticate")]
        [HttpPost]
        public IActionResult AuthenticateUser(LoginDetails loginDetails)
        {            
            if(validUser(loginDetails))
            {
                User userFromDB = _iJWTTokenInterface.GetAllUsers().Where(a => a.Email.ToLower() == loginDetails.Email.ToLower() &&
                                                                      a.Password == loginDetails.Password).ToList()[0];
                var token = _iJWTTokenInterface.GenerateToken(userFromDB);
                return Ok(token);
            }
            else
            {
                return Ok("Invalid Email or Password");
            }
        }

        private bool validUser(LoginDetails loginDetails) 
        {
            return _iJWTTokenInterface.GetAllUsers().Any(a => a.Email.ToLower() == loginDetails.Email.ToLower() && 
                                                          a.Password == loginDetails.Password);
        }
    }        
}