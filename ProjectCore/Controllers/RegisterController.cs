using Microsoft.AspNetCore.Mvc;

namespace ProjectCore.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}