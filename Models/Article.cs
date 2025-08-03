using System.ComponentModel.DataAnnotations.Schema;
namespace evanbuildsworldsAPI.Models
{
    [Table("article")]
    public class Article
    {
        public int id { get; set; }
        public int type { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime datePosted { get; set; }
        public DateTime dateEdited { get; set; }

        private Dictionary<string, int> Types = new Dictionary<string, int>
        {
            {"Unassigned", 0 },
            {"Character", 1 },
            {"History", 2 },
            {"Location", 3 },
            {"Item", 4 },
            {"Pantheon", 5 },
            {"Faction", 6 },
            {"BlogPost", 7 }
        };
    }
}
