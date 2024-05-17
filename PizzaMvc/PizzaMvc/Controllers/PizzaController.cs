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
            var pizza = PizzaManager.GetPizza(id);
            if (pizza != null)
                return View(pizza);
            else
                return View("errore");
        }

        [HttpGet]
        public IActionResult Create() // Restituisce la form per la creazione di pizze
        {
            Pizza p = new Pizza("Nome di default", "Descrizione base", 66.6M);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizzaDaInserire) // Restituisce la form per la creazione di pizze
        {
            if (ModelState.IsValid == false)
            {
                // Ritorno la form di prima con i dati della pizza
                // precompilati dall'utente
                return View("Create", pizzaDaInserire);
            }
            using (var db = new PizzaContext())
            {
                db.Add(pizzaDaInserire);
                db.SaveChanges();

                // Richiamiamo la action Index affinché vengano mostrate tutte le pizze
                // inclusa quella nuova
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
