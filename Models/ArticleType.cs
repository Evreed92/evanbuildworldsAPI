using System.ComponentModel.DataAnnotations.Schema;
namespace evanbuildsworldsAPI.Models
{
    [Table("types")]
    public class ArticleType
    {
        public int id { get; set; }
        public string name { get; set; }

        
    }
}
