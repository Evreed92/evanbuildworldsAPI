using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace evanbuildsworldsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogPostController : ControllerBase
    {

        private readonly ILogger<BlogPostController> _logger;
        private readonly MyDbContext _context;
        public BlogPostController(ILogger<BlogPostController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet(Name = "GetBlogPost")]
        public IActionResult GetAllPosts()
        {
            //1. Open a connection to the database
            //2. Query the database for all posts
            //3. store all posts in an array

            var posts = _context.BlogPost.ToList();
            if (!posts.Any()) return NotFound("No Posts Found.");

            return Ok(posts);
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
