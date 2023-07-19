using Microsoft.AspNetCore.Mvc;
using BlogService.Models;
using BlogService.Services;
using BlogService.DBContext;
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
        public readonly BlogDBContext _blogDBContext;
        public BlogController(IBlogInterface iBlogInterface, BlogDBContext blogDBContext)
        {
            _iBlogInterface = iBlogInterface;
            _blogDBContext = blogDBContext;
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
            Blog blog = _iBlogInterface.GetAllBlogs().Where(a => a.Id == id).ToList()[0];
            _iBlogInterface.DeleteBlogById(blog);
            return Ok("Blog deleted successfully");
        }

        [HttpGet]
        [Route("GetBlogById")]
        public ActionResult GetBlogById(int id)
        {
            List<Blog> blogs = _iBlogInterface.GetAllBlogs().Where(a =>
                                                a.Id == id).ToList();
            var blog = (from b in blogs
                        join u in _blogDBContext.Users
                        on b.CreatedBy equals u.Id
                        select new
                        {
                            id = b.Id,
                            blogName = b.BlogName,
                            category = b.Category,
                            article = b.Article,
                            createdBy = b.CreatedBy,
                            author = u.UserName,
                            email = u.Email,
                            createdOn = b.CreatedOn
                        }).ToList()[0];
            return Ok(blog);
        }

        [HttpGet]
        [Route("GetBlogsByUserId")]
        public ActionResult GetBlogsByUserId(int userId) 
        {
            List<Blog> blogsWithOutDetails = _iBlogInterface.GetAllBlogs().Where(a => a.CreatedBy == userId || a.CreatedBy == 1).ToList();
            var blogs = (from b in blogsWithOutDetails
                         join u in _blogDBContext.Users
                         on b.CreatedBy equals u.Id
                         select new {id = b.Id,
                                     blogName = b.BlogName,
                                     category = b.Category,
                                     article = b.Article,
                                     createdBy = b.CreatedBy,
                                     author = u.UserName,
                             createdOn = b.CreatedOn}).ToList();
            return Ok(blogs);
        }

        [HttpGet]
        [Route("GetBlogsBySearch")]
        public ActionResult GetBlogsBySearch(int userId, string category, DateTime fromdate, DateTime todate)
        {
            List<Blog> blogsWithOutDetails = _iBlogInterface.GetAllBlogs().Where(a => (a.CreatedBy == userId || a.CreatedBy == 1) &&
                                                                   a.Category.ToLower().Contains(category.ToLower()) && 
                                                                   fromdate <= a.CreatedOn && a.CreatedOn <= todate).ToList();
            var blogs = (from b in blogsWithOutDetails
                         join u in _blogDBContext.Users
                         on b.CreatedBy equals u.Id
                         select new
                         {
                             id = b.Id,
                             blogName = b.BlogName,
                             category = b.Category,
                             article = b.Article,
                             createdBy = b.CreatedBy,
                             author = u.UserName,
                             createdOn = b.CreatedOn
                         }).ToList();
            return Ok(blogs);
        }              
    }
}