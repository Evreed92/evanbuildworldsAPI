using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using evanbuildsworldsAPI.Models;

namespace evanbuildsworldsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {

        private readonly ILogger<BlogController> _logger;
        private readonly MyDbContext _context;
        public BlogController(ILogger<BlogController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        #region Get

        [HttpGet("GetAllPosts")]
        public IActionResult GetAllPosts()
        {
            var posts = _context.BlogPost.ToList();
            if (!posts.Any()) return NotFound("No Posts Found.");

            return Ok(posts);
        }

        [HttpGet("GetPostById")]
        public ActionResult<BlogPost> GetPostById(int id)
        {
            BlogPost post = new BlogPost();
            var posts = _context.BlogPost.ToList();
            if (!posts.Any()) return NotFound("No Posts Found.");
            {
                post = posts.FirstOrDefault(post => post.id == id);
            }
            return post;
        }

        #endregion



    }
}
