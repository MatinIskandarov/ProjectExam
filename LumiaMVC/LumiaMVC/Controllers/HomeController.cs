using Microsoft.AspNetCore.Mvc;

namespace LumiaMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
