using Microsoft.AspNetCore.Mvc;

namespace AppWeb.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
