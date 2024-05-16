using System.ComponentModel.DataAnnotations;

namespace BlogMvc.Models
{
    public class Post
    {
        [Key] public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Il titolo deve avere al più 50 caratteri")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Title { get; set; }
        [MinLength(10)]
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public Post()
        {
            Timestamp = DateTime.Now;
        }

        public Post(string title, string content) : this()
        {
            Title = title;
            Content = content;
        }
    }
}
