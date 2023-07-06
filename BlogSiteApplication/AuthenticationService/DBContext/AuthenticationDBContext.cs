using Microsoft.EntityFrameworkCore;
using RegistrationService.Models;

namespace AuthenticationService.DBContext
{
    public class AuthenticationDBContext : DbContext
    {
        public AuthenticationDBContext(DbContextOptions<AuthenticationDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
