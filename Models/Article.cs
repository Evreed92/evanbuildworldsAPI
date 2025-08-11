using System.ComponentModel.DataAnnotations.Schema;
namespace evanbuildsworldsAPI.Models
{
    [Table("articles")]
    public class Article
    {
        public int id { get; set; }
        public int typeId { get; set; }
        [NotMapped]
        public string? type { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime datePosted { get; set; }
        public DateTime dateEdited { get; set; }


    }
}
