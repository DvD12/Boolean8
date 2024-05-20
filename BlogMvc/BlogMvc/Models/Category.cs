using System.ComponentModel.DataAnnotations;

namespace BlogMvc.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }

        public List<Post> Posts { get; set; }

        public Category() { }
    }
}
