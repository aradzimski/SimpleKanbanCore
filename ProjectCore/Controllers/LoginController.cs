using Microsoft.AspNetCore.Mvc;

namespace ProjectCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}