using BlogService.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogService.DBContext
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
    }
}
