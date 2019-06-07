using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Migrations;
using ProjectCore.Models;
using ProjectCore.Repositories;
using Task = System.Threading.Tasks.Task;

namespace ProjectCore.Controllers
{
    public class KanbanController : Controller
    {
        private readonly UserManager<User> userManager;
        private TaskRepository taskRepository;

        public KanbanController(TaskRepository taskRepository, UserManager<User> userManager)
        {
            this.taskRepository = taskRepository;
            this.userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = await userManager.GetUserAsync(HttpContext.User);
                var tasks = taskRepository.GetAll();
                foreach (var task in tasks.Result)
                {
                    Debug.WriteLine("Taski" + task.name);
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}