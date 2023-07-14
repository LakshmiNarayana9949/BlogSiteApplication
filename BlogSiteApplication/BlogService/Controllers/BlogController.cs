using Microsoft.AspNetCore.Mvc;
using BlogService.Models;
using BlogService.Services;
using Microsoft.AspNetCore.Authorization;
using RegistrationService.Models;

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
            blog.Active = true;
            _iBlogInterface.AddNewBlog(blog);
            return Ok("Blog added Successfully");
        }

        [HttpDelete]
        [Route("DeleteBlogById")]
        public ActionResult DeleteBlogById(int id)
        {
            Blog blog = GetBlogById(id);
            _iBlogInterface.DeleteBlogById(blog);
            return Ok("Blog deleted successfully");
        }

        [HttpGet]
        [Route("GetBlogById")]
        public Blog GetBlogById(int id)
        {
            Blog blog = _iBlogInterface.GetAllBlogs().Where(a =>
                                                a.Id == id).ToList()[0];
            return blog;
        }

        [HttpGet]
        [Route("GetBlogsByUserId")]
        public ActionResult GetBlogsByUserId(int userId) 
        {
            List<Blog> blogs = _iBlogInterface.GetAllBlogs().Where(a => a.CreatedBy == userId).ToList();
            
            return Ok(blogs);
        }

        [HttpGet]
        [Route("GetBlogsBySearch")]
        public ActionResult GetBlogsBySearch(int userId, string category, DateTime fromdate, DateTime todate)
        {
            List<Blog> blogs = _iBlogInterface.GetAllBlogs().Where(a => a.CreatedBy == userId &&
                                                                   a.Category.ToLower().Contains(category.ToLower()) && 
                                                                   fromdate <= a.CreatedOn && a.CreatedOn <= todate).ToList();
            return Ok(blogs);
        }              
    }
}