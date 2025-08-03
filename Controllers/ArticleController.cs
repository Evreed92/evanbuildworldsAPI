using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using evanbuildsworldsAPI.Models;

namespace evanbuildsworldsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {

        private readonly ILogger<ArticleController> _logger;
        private readonly MyDbContext _context;
        public ArticleController(ILogger<ArticleController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        #region Get

        [HttpGet("GetAllArticles")]
        public IActionResult GetAllArticles()
        {
            var posts = _context.Article.ToList();
            if (!posts.Any()) return NotFound("No Posts Found.");

            return Ok(posts);
        }

        [HttpGet("GetArticleById")]
        public ActionResult<Article> GetArticleById(int id)
        {
            Article post = new Article();
            var posts = _context.Article.ToList();
            if (!posts.Any()) return NotFound("No Articles Found.");
            {
                post = posts.FirstOrDefault(post => post.id == id);
            }
            return post;
        }

        #endregion



    }
}
