using Microsoft.AspNetCore.Mvc;

namespace PizzaMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
