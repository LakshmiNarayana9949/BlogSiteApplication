using BlogService.DBContext;
using BlogService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlogService.Services
{    
    public class BlogImpl : IBlogInterface
    {
        private readonly BlogDBContext _blogDbContext;
        public BlogImpl(BlogDBContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public void AddNewBlog(Blog blog)
        {
            _blogDbContext.Add(blog);
            save();            
        }

        public void DeleteBlogById(Blog blog)
        {
            blog.Active = false;
            _blogDbContext.Entry(blog).State = EntityState.Modified;
            save();
        }

        public List<Blog> GetAllBlogs()
        {
            return _blogDbContext.Blogs.ToList().Where(a => a.Active == true).ToList();
        }

        private void save()
        {
            _blogDbContext.SaveChanges();
        }
    }
}
