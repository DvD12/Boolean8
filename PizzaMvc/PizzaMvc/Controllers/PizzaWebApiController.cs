using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaMvc.Data;
using PizzaMvc.Models;

namespace PizzaMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaWebApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPizzas()
        {
            var pizzas = PizzaManager.GetAllPizzas();
            return Ok(pizzas);
        }

        [HttpGet]
        public IActionResult GetPizzaById(int id) // QUERY PARAM https://.../api/pizzawebapi/getpizzabyid?id=1
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza == null)
                return NotFound("ERRORE");
            return Ok(pizza);
        }

        [HttpGet("{name}")]
        public IActionResult GetPizzaByName(string name) // PATH PARAM https://.../api/pizzawebapi/getpizzabyname/margherita
        {
            var pizza = PizzaManager.GetPizzaByName(name);
            if (pizza == null)
                return NotFound("ERRORE");
            return Ok(pizza);
        }

        [HttpPost]
        // Pizza deve essere incluso nella richiesta POST
        // (come documento JSON che il framework deserializzerà automaticamente in oggetto di tipo Pizza)
        public IActionResult CreatePizza([FromBody] Pizza pizza)
        {
            PizzaManager.InsertPizza(pizza, null);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, [FromBody] Pizza pizza)
        {
            var oldPizza = PizzaManager.GetPizza(id);
            if (oldPizza == null)
                return NotFound("ERRORE");
            PizzaManager.UpdatePizza(id, pizza, null);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            bool found = PizzaManager.DeletePizza(id);
            if (found)
                return Ok();
            return NotFound();
        }
    }
}
