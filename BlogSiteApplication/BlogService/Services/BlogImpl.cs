using BlogService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Services
{
    public class BlogImpl : IBlogInterface
    {
        public ActionResult AddNewBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteBlogById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAllBlogs()
        {
            throw new NotImplementedException();
        }

        public Blog GetBlogById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
