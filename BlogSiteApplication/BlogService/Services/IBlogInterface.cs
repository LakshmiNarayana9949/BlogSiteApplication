using BlogService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Services
{
    public interface IBlogInterface
    {
        public ActionResult AddNewBlog(Blog blog);
        public List<Blog> GetAllBlogs();
        public Blog GetBlogById(int id);
        public ActionResult DeleteBlogById(int id);
    }
}
