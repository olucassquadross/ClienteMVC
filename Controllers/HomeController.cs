using Microsoft.AspNetCore.Mvc;

namespace ClienteMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
