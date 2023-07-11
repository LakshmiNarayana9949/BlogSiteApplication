using Microsoft.AspNetCore.Mvc;
using BlogService.Models;
using BlogService.Services;
using Microsoft.AspNetCore.Authorization;

namespace BlogService.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        public readonly IBlogInterface _iBlogInterface;
        public BlogController(IBlogInterface iBlogInterface)
        {
            _iBlogInterface = iBlogInterface;
        }
        
        [HttpPost]
        [Route("AddNewBlog")]
        public ActionResult AddNewBlog(Blog blog) 
        {
            _iBlogInterface.AddNewBlog(blog);
            return Ok("Blog added Successfully");
        }

        [HttpGet]
        [Route("GetAllBlogs")]
        public ActionResult GetAllBlogs()
        {
            List<Blog> blogs = _iBlogInterface.GetAllBlogs();
            return Ok(blogs);
        }

        [HttpGet]
        [Route("GetBlogsByUserId")]
        public ActionResult GetBlogsByUserId(int userId) 
        {
            List<Blog> blogs = _iBlogInterface.GetAllBlogs().Where(a => a.CreatedBy == userId).ToList();
            return Ok(blogs);
        }

        [HttpGet]
        [Route("GetBlogsByCategory")]
        public ActionResult GetBlogsByCategory(string category)
        {
            List<Blog> blogs = _iBlogInterface.GetAllBlogs().Where(a => 
                                                a.Category.ToLower() == category.ToLower()).ToList();
            return Ok(blogs);
        }

        [HttpGet]
        [Route("GetBlogById")]
        public ActionResult GetBlogById(int id)
        {
            Blog blog = _iBlogInterface.GetAllBlogs().Where(a =>
                                                a.Id == id).ToList()[0];
            return Ok(blog);
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult DeleteBlogById(int id)
        {
            return Ok("Blog deleted successfully");
        }
    }
}