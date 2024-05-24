using BlogMvc.Data;
using BlogMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostWebController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPosts(string? name)
        {
            if (name == null)
                return Ok(PostManager.GetAllPosts());
            return Ok(PostManager.GetPostsByTitle(name)); // ritorna soltanto i post che contengono name nel titolo
        }

        [HttpGet]
        public IActionResult GetPostById(int id) // QUERY PARAM https://.../api/Postwebapi/getPostbyid?id=1
        {
            var Post = PostManager.GetPost(id);
            if (Post == null)
                return NotFound("ERRORE");
            return Ok(Post);
        }

        [HttpGet("{name}")]
        public IActionResult GetPostByTitle(string name) // PATH PARAM https://.../api/Postwebapi/getPostbyTitle/post1
        {
            var Post = PostManager.GetPostsByTitle(name);
            if (Post == null)
                return NotFound("ERRORE");
            return Ok(Post);
        }

        [HttpPost]
        // Post deve essere incluso nella richiesta POST
        // (come documento JSON che il framework deserializzerà automaticamente in oggetto di tipo Post)
        public IActionResult CreatePost([FromBody] Post Post)
        {
            PostManager.InsertPost(Post, null);
            return Ok();
        }
        // restituire la lista di tutte le nostre pizze
        // (deve essere possibile passare un parametro di filtro e restituire le pizze il cui titolo contiene il filtro inviato)
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] Post Post)
        {
            var oldPost = PostManager.GetPost(id);
            if (oldPost == null)
                return NotFound("ERRORE");
            PostManager.UpdatePost(id, Post.Title, Post.Content, Post.CategoryId, null);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            bool found = PostManager.DeletePost(id);
            if (found)
                return Ok();
            return NotFound();
        }
    }
}
