using RegistrationService.Models;
using RegistrationService.DBContext;

namespace RegistrationService.Services
{
    public class UserImpl : IUserInterface
    {
        public readonly UserDBContext _userDBContext;
        public UserImpl(UserDBContext userDBContext) 
        {
            _userDBContext= userDBContext;
        }
        public void AddUser(User user)
        {
            _userDBContext.Users.Add(user);
            save();
        }

        public void save()
        {
            _userDBContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _userDBContext.Users.ToList();
        }
    }
}
