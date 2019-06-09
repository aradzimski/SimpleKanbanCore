using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens.Saml;
using ProjectCore.Models;
using ProjectCore.Repositories;
using Task = ProjectCore.Models.Task;

namespace ProjectCore.Controllers
{
    public class TaskController : Controller
    {
        private TaskTypeRepository taskTypeRepository;
        private TaskRepository taskRepository;
        private readonly UserManager<User> userManager;

        public TaskController(TaskTypeRepository taskTypeRepository, TaskRepository taskRepository, UserManager<User> userManager)
        {
            this.taskTypeRepository = taskTypeRepository;
            this.taskRepository = taskRepository;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Add()
        {
           if (User.Identity.IsAuthenticated)
           {
           var types = taskTypeRepository.GetAll().Result;
           ViewData["TaskTypes"] = new SelectList(types, "Id", "name");

           var users = await userManager.Users.ToListAsync();
           ViewData["Users"] = new SelectList(users, "Id", "UserName");

           List<object> stateslist = new List<object>();
           stateslist.Add(new {Id = 0, name = "To Do"});
           stateslist.Add(new {Id = 1, name = "In progress"});
           stateslist.Add(new {Id = 2, name = "Awaiting"});
           stateslist.Add(new {Id = 3, name = "Testing"});
           stateslist.Add(new {Id = 4, name = "Done"});
           IEnumerable<object> states = stateslist;
           ViewData["States"] = new SelectList(states, "Id", "name");
           
           return View();
           }
           else
           {
               return RedirectToAction("Index", "Home");
           }
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(TaskAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Nazwa: " + vm.name + " Opis: " + vm.description + " Typ: " + vm.type + " Status: " + vm.state + " Osoba wykonująca: " + vm.assignee);
                
                TaskType type = await taskTypeRepository.GetById(vm.type);
                User reporter = await userManager.GetUserAsync(HttpContext.User);
                User assignee= await userManager.FindByIdAsync(vm.assignee);
                
                Task task = new Task();
                task.name = vm.name;
                task.description = vm.description;
                task.type = type;
                task.reporter = reporter;
                task.assignee = assignee;
                task.state = vm.state;
                
                await taskRepository.Add(task);
                return RedirectToAction("Index", "Kanban");
            }

            return View(vm);
        }
        
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