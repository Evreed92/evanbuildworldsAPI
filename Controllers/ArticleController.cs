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
            var articles = _context.Article.ToList();
            if (!articles.Any()) return NotFound("No Posts Found.");

            return Ok(articles);
        }

        [HttpGet("GetArticleById")]
        public ActionResult<Article> GetArticleById(int id)
        {
            Article post = new Article();
            var posts = _context.Article.ToList();
            if (!posts.Any()) return NotFound("No Articles Found.");
            
            post = posts.FirstOrDefault(post => post.id == id);
            return post;
        }

        [HttpGet("GetArticlesByType")]
        public ActionResult<List<Article>> GetArticlesByType(string type)
        {
            // Turn Type into the corresponding Int
            Article TestArticle = new Article(type);
            var typeId = TestArticle.typeId;

            List<Article> posts = new List<Article>();
            var db = _context.Article.Where(article => article.typeId == typeId).ToList();
            if (!db.Any()) return NotFound("No Articles Found.");

            return db;
        }

        //GetArticleByTitle



        #endregion



    }
}
