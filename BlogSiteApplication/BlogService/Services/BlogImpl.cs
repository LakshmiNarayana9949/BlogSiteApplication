using BlogService.DBContext;
using BlogService.Models;
using Microsoft.AspNetCore.Mvc;
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

        public void DeleteBlogById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAllBlogs()
        {
            return _blogDbContext.Blogs.ToList();
        }

        public Blog GetBlogById(int id)
        {
            throw new NotImplementedException();
        }

        private void save()
        {
            _blogDbContext.SaveChanges();
        }
    }
}
