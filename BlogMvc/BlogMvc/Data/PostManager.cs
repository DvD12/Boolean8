using BlogMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlogMvc.Data
{
    public static class PostManager
    {
        public static int CountAllPosts()
        {
            using BlogContext db = new BlogContext();
            return db.Posts.Count();
        }

        public static List<Post> GetAllPosts()
        {
            using BlogContext db = new BlogContext();
            return db.Posts.ToList();
        }

        public static List<Category> GetAllCategories()
        {
            using BlogContext db = new BlogContext();
            return db.Categories.ToList();
        }

        public static List<Tag> GetAllTags()
        {
            using BlogContext db = new BlogContext();
            return db.Tags.ToList();
        }

        public static Post GetPost(int id, bool includeReferences = true)
        {
            using BlogContext db = new BlogContext();
            if (includeReferences)
                return db.Posts.Where(p => p.Id == id).Include(p => p.Category).Include(p => p.Tags).FirstOrDefault();
            return db.Posts.FirstOrDefault(p => p.Id == id);
        }

        public static List<Post> GetPostsByTitle(string title)
        {
            using BlogContext db = new BlogContext();
            return db.Posts.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public static Tag GetTagById(int id)
        {
            using BlogContext db = new BlogContext();
            return db.Tags.FirstOrDefault(t => t.Id == id);
        }

        public static void InsertPost(Post Post, List<string> SelectedTags = null)
        {
            using BlogContext db = new BlogContext();
            if (SelectedTags != null)
            {
                Post.Tags = new List<Tag>();
                // Trasformiamo gli ID scelti in tag da aggiungere tra i riferimenti in Post
                foreach (var tagId in SelectedTags)
                {
                    int id = int.Parse(tagId);
                    var tag = db.Tags.FirstOrDefault(t => t.Id == id); // PostManager.GetTagById(id); NON usiamo GetTagById() perché usa un db context diverso e ciò causerebbe errore in fase di salvataggio - usiamo lo stesso context all'interno della stessa operazione
                    Post.Tags.Add(tag);
                }
            }
            db.Posts.Add(Post);
            db.SaveChanges();
        }

        public static bool UpdatePost(int id, Action<Post, List<Tag>> edit, List<string> tags)
        {
            using BlogContext db = new BlogContext();
            var post = db.Posts.Where(x => x.Id == id).Include(x => x.Tags).FirstOrDefault();

            if (post == null)
                return false;

            List<Tag> tagsFromDb = new List<Tag>();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    int tagId = int.Parse(tag);
                    var tagFromDb = db.Tags.FirstOrDefault(x => x.Id == tagId);
                    tagsFromDb.Add(tagFromDb);
                }
            }

            edit(post, tagsFromDb);

            db.SaveChanges();

            return true;
        }

        public static bool UpdatePost(int id, string title,
            string content, int? categoryId, List<string> tags)
        {
            using BlogContext db = new BlogContext();
            var post = db.Posts.Where(x => x.Id == id).Include(x => x.Tags).FirstOrDefault();

            if (post == null)
                return false;

            post.Title = title;
            post.Content = content;
            post.CategoryId = categoryId;

            post.Tags.Clear(); // Prima svuoto così da salvare solo le informazioni che l'utente ha scelto, NON le aggiungiamo ai vecchi dati
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    int tagId = int.Parse(tag);
                    var tagFromDb = db.Tags.FirstOrDefault(x => x.Id == tagId);
                    post.Tags.Add(tagFromDb);
                }
            }

            db.SaveChanges();

            return true;
        }

        public static bool DeletePost(int id)
        {
            using BlogContext db = new BlogContext();
            var post = db.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
                return false;

            db.Posts.Remove(post);
            db.SaveChanges();

            return true;
        }

        public static void Seed()
        {
            if (PostManager.CountAllPosts() == 0)
            {
                PostManager.InsertPost(new Post("HELLO WORLD!!1!12", "My first post"));
                PostManager.InsertPost(new Post("HELLO WORLD!11!1", "answer pls"));
                PostManager.InsertPost(new Post("I said HELLO234917234", "WTF ANSWER ME"));
            }
        }
    }
}
