using Microsoft.AspNetCore.Mvc;
using WEBAPP.DB;

namespace WEBAPP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
