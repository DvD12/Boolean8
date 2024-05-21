using Microsoft.AspNetCore.Mvc;
using PizzaMvc.Data;
using PizzaMvc.Models;
using System.Diagnostics;

namespace PizzaMvc.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizzas());
        }

        [HttpGet]
        public IActionResult GetPizza(int id)
        {
            try
            {
                var pizza = PizzaManager.GetPizza(id);
                if (pizza != null)
                    return View(pizza);
                else
                    //return NotFound();
                    return View("Errore", new ErroreViewModel($"La pizza {id} non è stata trovata!"));
            }
            catch (Exception e)
            {
                return View("Errore", new ErroreViewModel(e.Message));
                //return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult CreatePizza() // Restituisce la form per la creazione di pizze
        {
            Pizza p = new Pizza("Nome di default", "Descrizione base", 66.6M);
            List<Category> categories = PizzaManager.GetAllCategories();
            PizzaFormModel model = new PizzaFormModel(p, categories);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePizza(PizzaFormModel pizzaDaInserire)
        {
            if (ModelState.IsValid == false)
            {
                // Ritorno la form di prima con i dati della pizza
                // precompilati dall'utente
                pizzaDaInserire.Categories = PizzaManager.GetAllCategories();
                return View("CreatePizza", pizzaDaInserire);
            }

            PizzaManager.InsertPizza(pizzaDaInserire.Pizza);
            // Richiamiamo la action Index affinché vengano mostrate tutte le pizze
            // inclusa quella nuova
            return RedirectToAction("Index");
        }

        [HttpGet]
        // Mi serve l'ID della pizza per:
        // 1) Indicare alla view QUALE pizza devo modificare
        // 2) Popolare la form della view coi dati della pizza che sto per modificare
        public IActionResult UpdatePizza(int id) // Restituisce la form per l'update di una pizza
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza == null)
                return NotFound();
            PizzaFormModel model = new PizzaFormModel(pizza, PizzaManager.GetAllCategories());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePizza(int id, PizzaFormModel pizzaDaModificare) // Restituisce la form per la creazione di pizze
        {
            if (ModelState.IsValid == false)
            {
                // Ritorno la form di prima con i dati della pizza
                // precompilati dall'utente
                pizzaDaModificare.Categories = PizzaManager.GetAllCategories();
                return View("UpdatePizza", pizzaDaModificare);
            }

            var modified = PizzaManager.UpdatePizza(id, pizzaDaModificare.Pizza);
            if (modified)
            {
                // Richiamiamo la action Index affinché vengano mostrate tutte le pizze
                return RedirectToAction("Index");
            }
            else
                return NotFound();

            /*
            var state = PizzaManager.UpdatePizzaWithEnum(id, pizzaDaModificare);
            switch (state)
            {
                case ResultType.OK:
                    return RedirectToAction("Index");
                    break;
                case ResultType.NotFound:
                    return NotFound();
                    break;
                case ResultType.Exception:
                    return NotFound();
                    break;
            }
            */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePizza(int id)
        {
            var deleted = PizzaManager.DeletePizza(id);
            if (deleted)
            {
                // Richiamiamo la action Index affinché vengano mostrate tutte le pizze
                return RedirectToAction("Index");
            }
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
