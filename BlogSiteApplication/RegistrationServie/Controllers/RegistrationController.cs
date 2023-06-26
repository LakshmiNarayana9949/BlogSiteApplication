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
        public void AddUser(User user)
        {
            _iUserInterface.AddUser(user);
        }
    }
}