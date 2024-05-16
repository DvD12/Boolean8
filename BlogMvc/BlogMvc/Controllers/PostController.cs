using BlogMvc.Data;
using BlogMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogMvc.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(PostManager.GetAllPosts());
        }

        public IActionResult GetPost(int id)
        {
            var Post = PostManager.GetPost(id);
            if (Post != null)
                return View(Post);
            else
                return View("errore");
        }

        // Action che fornisce la view con la form
        // per creare un nuovo post del blog
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Action richiamata dalla view tramite la form
        // (view che le passa il Post "data", fornito dalla form)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post data)
        {
            if (!ModelState.IsValid)
            {
                // Ritorniamo "data" alla view così che la form abbia di nuovo i dati inseriti
                // (anche se erronei)
                return View("Create", data);
            }

            PostManager.InsertPost(data);
            using (BlogContext db = new BlogContext())
            {
                var postToCreate = new Post(data.Title, data.Content);
                db.Posts.Add(postToCreate);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
