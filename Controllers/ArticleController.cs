using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using evanbuildsworldsAPI.Models;

namespace evanbuildsworldsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        #region Properties  
        private readonly ILogger<ArticleController> _logger;
        private readonly MyDbContext _context;

        #endregion
        #region Constructors
        public ArticleController(ILogger<ArticleController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        #endregion
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
            //Article TestArticle = new Article(type);
            //var typeId = TestArticle.typeId;

            //List<Article> posts = new List<Article>();
            //var db = _context.Article.Where(article => article.typeId == typeId).ToList();
            //if (!db.Any()) return NotFound("No Articles Found.");

            /*Rework...
             * 
             * Pull from types dbTable
             * find the corresponding id to the given type
             * 
             * pull from article table using the corresponding id
             * return list of articles
            */

            List<ArticleTypes> typesList = new List<ArticleTypes>();
            var dbTypes = _context.ArticleTypes.ToList();
            var givenType = 0;

            foreach (var typePair in dbTypes) {
                if (typePair.name == type) {
                    givenType = typePair.id;
                } 
            }

            List<Article> articles = new List<Article>();
            var dbArticles = _context.Article.Where(article => article.typeId == givenType).ToList();

            return dbArticles;
        }

        //GetArticleByTitle



        #endregion
        #region Set
        /*
         * Methods to Build
         * 
         * 1. CreateNewArticle
         * 2. EditExistingArticle
         * 3. DeleteArticle
         * 
         */


        #endregion

    }
}
