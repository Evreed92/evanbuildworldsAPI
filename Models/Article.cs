using System.ComponentModel.DataAnnotations.Schema;
namespace evanbuildsworldsAPI.Models
{
    [Table("article")]
    public class Article
    {
        public int id { get; set; }
        public int typeId { get; set; }
        [NotMapped]
        public string type { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime datePosted { get; set; }
        public DateTime dateEdited { get; set; }

        private Dictionary<int, string> Types = new Dictionary<int, string>
        {
            {0, "Unassigned"},
            {1, "Character"},
            {2, "History"},
            {3, "Location"},
            {4, "Item"},
            {5, "Pantheon"},
            {6, "Faction"},
            {7, "BlogPost"}
        };

        //Constructors
        public Article()
        {
            SetType();
        }

       public Article(string type)
        {
            this.type = type;
            GetTypeId();
        } 

        private void SetType()
        {
            type = Types[typeId];
        }
        private void GetTypeId()
        {
            var keys = Types.First(pair => pair.Value == type);
            this.typeId = keys.Key;
        }
    }
}
