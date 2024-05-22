using BlogMvc.Code;
using BlogMvc.Data;
using BlogMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace BlogMvc.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private ICustomLogger customLogger;

        public PostController(ILogger<PostController> logger, ICustomLogger customLogger)
        {
            _logger = logger;
            this.customLogger = customLogger;
        }

        public IActionResult Index()
        {
            customLogger.WriteLog("Sono entrato nell'index");
            return View(PostManager.GetAllPosts());
        }

        public IActionResult GetPost(int id)
        {
            var Post = PostManager.GetPost(id, true);
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
            PostFormModel model = new PostFormModel();
            model.Post = new Post();
            model.Categories = PostManager.GetAllCategories();
            model.CreateTags();
            return View(model);
        }

        // Action richiamata dalla view tramite la form
        // (view che le passa il Post "data", fornito dalla form)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Create(PostFormModel data)
        {
            if (!ModelState.IsValid)
            {
                // Ritorniamo "data" alla view così che la form abbia di nuovo i dati inseriti
                // (anche se erronei)
                data.Categories = PostManager.GetAllCategories();
                data.CreateTags();
                return View("Create", data);
            }

            PostManager.InsertPost(data.Post, data.SelectedTags);
            /*
            using (BlogContext db = new BlogContext())
            {
                var postToCreate = new Post(data.Title, data.Content);
                db.Posts.Add(postToCreate);
                db.SaveChanges();
            }
            */
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // Prendo il post AGGIORNATO da database, non
            // uno passato da utente alla action
            var postToEdit = PostManager.GetPost(id);

            if (postToEdit == null)
            {
                return NotFound();
            }
            else
            {
                PostFormModel model = new PostFormModel(postToEdit, PostManager.GetAllCategories());
                model.CreateTags();
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PostFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.Categories = PostManager.GetAllCategories();
                data.CreateTags();
                return View("Update", data);
            }

            // MODIFICA "STANDARD"
            if (PostManager.UpdatePost(id, data.Post.Title, data.Post.Content, data.Post.CategoryId, data.SelectedTags))
                return RedirectToAction("Index");
            else
                return NotFound();

            // MODIFICA TRAMITE LAMBDA
            bool result = PostManager.UpdatePost(id, (postToEdit, selectedTags) =>
            {
                postToEdit.Title = data.Post.Title;
                postToEdit.Content = data.Post.Content;
                postToEdit.CategoryId = data.Post.CategoryId;
                postToEdit.Tags.Clear();
                foreach (var tag in selectedTags)
                    postToEdit.Tags.Add(tag);
            }, data.SelectedTags);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            // Se voglio specificare l'url del chiamante come redirect
            // posso indagare sulla richiesta:
            //   var url = HttpContext.Request.Headers["Referer"];
            // e poi fare Redirect()
            //   return Redirect(url);
            // Fonti:
            // https://stackoverflow.com/questions/815229/how-do-i-redirect-to-the-previous-action-in-asp-net-mvc

            if (PostManager.DeletePost(id))
                return RedirectToAction("Index");
            else
                return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
