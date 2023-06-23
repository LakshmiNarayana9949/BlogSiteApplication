using RegistrationService.Models;
using System.Reflection.Metadata.Ecma335;

namespace RegistrationService.Services
{
    public interface IUserInterface
    {
        public void AddUser(User user);
        public List<User> GetAllUsers();
    }
}
