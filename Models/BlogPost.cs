using System.ComponentModel.DataAnnotations.Schema;
namespace evanbuildsworldsAPI.Models
{
    [Table("blog_post")]
    public class BlogPost
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime datePosted { get; set; }
        public DateTime dateEdited { get; set; }
    }
}
