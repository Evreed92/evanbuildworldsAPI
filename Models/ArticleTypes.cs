using System.ComponentModel.DataAnnotations.Schema;
namespace evanbuildsworldsAPI.Models
{
    [Table("types")]
    public class ArticleTypes
    {
        public int id { get; set; }
        public string name { get; set; }

        
    }
}
