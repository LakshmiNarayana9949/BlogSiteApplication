using Microsoft.AspNetCore.Mvc;
using RegistrationService.Models;
using RegistrationService.Services;

namespace RegistrationServie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        public readonly IUserInterface _iUserInterface;
        public RegistrationController(IUserInterface iUserInterface)
        {
            _iUserInterface = iUserInterface;
        }
        [Route("Register")]
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            try
            {
                List<User> users = _iUserInterface.GetAllUsers();
                if (users.Any(a => a.Email == user.Email || a.UserName == user.UserName))
                {
                    return Ok("Email or Username already exists.");
                }
                else
                {
                    _iUserInterface.AddUser(user);
                    return Ok("User registered successfully");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}