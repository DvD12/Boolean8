using BlogMvc.Models;
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

        public static Post GetPost(int id, bool includeReferences = true)
        {
            using BlogContext db = new BlogContext();
            if (includeReferences)
                return db.Posts.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
            return db.Posts.FirstOrDefault(p => p.Id == id);
        }

        public static void InsertPost(Post Post)
        {
            using BlogContext db = new BlogContext();
            db.Posts.Add(Post);
            db.SaveChanges();
        }

        public static bool UpdatePost(int id, Action<Post> edit)
        {
            using BlogContext db = new BlogContext();
            var post = db.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
                return false;

            edit(post);

            db.SaveChanges();

            return true;
        }

        public static bool UpdatePost(int id, string title, string content, int? categoryId)
        {
            using BlogContext db = new BlogContext();
            var post = db.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
                return false;

            post.Title = title;
            post.Content = content;
            post.CategoryId = categoryId;

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
