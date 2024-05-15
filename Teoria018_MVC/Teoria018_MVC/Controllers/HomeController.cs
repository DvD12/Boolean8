using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Teoria018_MVC.Models;

namespace Teoria018_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Profile p1 = new Profile("Pinco Jr.", "Panco", 30);
            Profile p2 = new Profile("Pinco Sr.", "Panco", 60);

            // ViewData è un dizionario che associa stringhe a oggetti
            // Quindi quando lo uso non conosco il tipo esatto dei suoi valori:
            // dovrei fare il cast manuale dei valori, che è pericoloso
            ViewData["Profilo1"] = p1;

            HomeIndexViewModel vm = new HomeIndexViewModel();
            vm.Profilo = p2;
            vm.Messaggio = "Ciao, io sono un viewmodel fastidioso";

            return View(vm); // vm: assegno un modello alla view
            // COMUNQUE la View avrà sia la ViewData e anche vm
        }

        //public IActionResult ProvaParametri(string nome, int numero)
        public IActionResult ProvaParametri(ProvaParametriViewModel vm)
        {
            /*var ciao = new ProvaParametriViewModel()
            {
                Nome = "Ciao",
                Numero = 123123,
            };*/
            /*var oggettoAnonimo = new // oggetto anonimo
            {
                Nome = "Ciao",
                Numero = 123123,
            };*/
            // Potrei anche accedere a tutte le coppie chiave=valore tramite Request.Query
            //var a1 = HttpContext.Request.Query;
            //var a2 = this.Request.Query;
            
            //ProvaParametriViewModel vm = new ProvaParametriViewModel();
            //vm.Numero = numero;
            //vm.Nome = nome;
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
