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

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Tag>? Tags { get; set; }
        
        public byte[]? ImageFile { get; set; }
        public string ImgSrc => ImageFile != null ? $"data:image/png;base64,{Convert.ToBase64String(ImageFile)}" : "";

        public Post()
        {
            Timestamp = DateTime.Now;
        }

        public Post(string title, string content) : this()
        {
            Title = title;
            Content = content;
        }

        public string GetDisplayedCategory()
        {
            if (Category == null)
                return "Nessuna categoria";
            return Category.Title;

            // Versione più sintetica:
            //return Category?.Title ?? "Nessuna categoria";
        }
    }
}
