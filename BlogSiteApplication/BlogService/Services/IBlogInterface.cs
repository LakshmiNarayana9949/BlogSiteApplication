using BlogService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Services
{
    public interface IBlogInterface
    {
        public void AddNewBlog(Blog blog);
        public List<Blog> GetAllBlogs();        
        public void DeleteBlogById(Blog blog);
    }
}
