namespace BlogMvc.Models
{
    public class PostFormModel
    {
        public Post Post { get; set; }
        public List<Category>? Categories { get; set; }

        public PostFormModel() { }

        public PostFormModel(Post p, List<Category> c)
        {
            this.Post = p;
            this.Categories = c;
        }
    }
}
