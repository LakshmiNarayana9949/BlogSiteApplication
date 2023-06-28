using Microsoft.EntityFrameworkCore;
using RegistrationService.Models;

namespace RegistrationService.DBContext
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
