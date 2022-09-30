using Microsoft.AspNetCore.Mvc;

namespace MarketProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
