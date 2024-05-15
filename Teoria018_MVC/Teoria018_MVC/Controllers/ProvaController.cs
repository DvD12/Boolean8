using Microsoft.AspNetCore.Mvc;

namespace Teoria018_MVC.Controllers
{
    public class ProvaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public void ShowPizza(int id)
        {
            Pizza p = GetMyPizza(id);
            return View(p);
        }
    }
}
