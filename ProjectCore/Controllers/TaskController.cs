using Microsoft.AspNetCore.Mvc;

namespace ProjectCore.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        
        /*public IActionResult actionAdd()
        {
            return View();
        }*/
        
        public IActionResult Edit(int id)
        {
            return View();
        }
        
        /*public IActionResult actionEdit()
        {
            return View();
        }
        
        public IActionResult Delete()
        {
            return View();
        }*/
    }
}