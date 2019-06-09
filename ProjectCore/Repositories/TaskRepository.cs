using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectCore.Context;
using ProjectCore.Models;
using ETask = ProjectCore.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace ProjectCore.Repositories
{
    public class TaskRepository : IRepository<ETask>
    {
        private readonly ProjectCoreContext _projectCoreContext;
        
        public TaskRepository(ProjectCoreContext projectCoreContext)
        {
            _projectCoreContext = projectCoreContext;
        }

        public async Task<IEnumerable<ETask>> GetAll()
        {
            var result = await _projectCoreContext.Task.ToListAsync();
        return result;
        }

        public async Task<ETask> GetById(long id)
        {
            var result = await _projectCoreContext.Task
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<ETask>> GetUserTasks(User user)
        {
            var result = await _projectCoreContext.Task
                .Include(task => task.type)
                .Include(task => task.assignee)
                .Include(task => task.reporter)
                .Where((x => x.assignee == user))
                .ToListAsync();
            return result;
        }

        public async Task Add(ETask task)
        {
            task.DateOfCreation = DateTime.Now;
            task.DateOfUpdate = DateTime.Now;
            var result = await _projectCoreContext.Task
                .FirstAsync();
            await _projectCoreContext.Task.AddAsync(task);
            await _projectCoreContext.SaveChangesAsync();
        }

        public async Task Update(ETask entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}