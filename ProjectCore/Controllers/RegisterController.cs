using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Models;

namespace ProjectCore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = new User { UserName = vm.UserName, PasswordHash = vm.Password};
            var result = await _userManager.CreateAsync(user, vm.Password);

            Debug.WriteLine(result.Errors);
            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            
                return View(vm);
            }
        }
    }
}