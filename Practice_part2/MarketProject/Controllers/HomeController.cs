using Microsoft.AspNetCore.Mvc;

namespace MarketProject.Controllers
{
    //for_review
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
