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

        //TEST
       // private static readonly string[] Summaries = new[]
       //{
       //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
       // };

       // [HttpGet(Name = "GetBlogPostWeather")]
       // public IEnumerable<WeatherForecast> Get()
       // {
       //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
       //     {
       //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
       //         TemperatureC = Random.Shared.Next(-20, 55),
       //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
       //     })
       //     .ToArray();
       // }



    }
}
