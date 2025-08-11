using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using evanbuildsworldsAPI.Models;
using System.Collections.Immutable;

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

        [HttpGet("GetArticleTypes")]
        public List<ArticleType> GetArticleTypes()
        {
            var types = _context.ArticleType.ToList();
            
            return types;
        }


        [HttpGet("GetAllArticles")]
        public IActionResult GetAllArticles()
        {
            var types = GetArticleTypes();
            var articles = _context.Article.ToList();
            if (!articles.Any()) return NotFound("No Posts Found.");
            foreach (Article article in articles)
            {
                foreach (ArticleType type in types)
                {
                    if (article.typeId == 0) article.type = null;
                    if (article.typeId == type.id) article.type = type.name;
                }

            }
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

        //Needs to be reworked
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

            List<ArticleType> typesList = new List<ArticleType>();
            var dbTypes = _context.ArticleType.ToList();
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
        #region Post and Put
      
        [HttpPost("CreateArticle")]
        public async Task<Article> CreateArticle(Article article) 
        {
            //def have bugs to work out with regard to the article properties and the db interaction.
            _context.Article.Add(article);
            await _context.SaveChangesAsync();

            return article;
        }

        [HttpPut("EditArticle")]
        public async Task<IActionResult> EditArticle(Article article)
        {
            var dbArticle = await _context.Article.FindAsync(article.id);
            if (dbArticle != null)
            {
                dbArticle.id = article.id;
                dbArticle.title = article.title;
                dbArticle.dateEdited = article.dateEdited;
                dbArticle.content = article.content;
                dbArticle.typeId = article.typeId;

                _context.Article.Update(dbArticle);
                await _context.SaveChangesAsync();

                return Ok(article);
            }
            if (dbArticle == null)
            {
                return NotFound();
            }
            return NotFound();
            
        }

        #endregion
        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Article.FindAsync(id);
            if (item == null)
            {
                return NotFound(); //404
            }

            _context.Article.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent(); //204

        }
        #endregion

    }
}
