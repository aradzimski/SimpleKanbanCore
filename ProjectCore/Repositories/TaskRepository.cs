using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectCore.Context;
using ETask = ProjectCore.Models.Task;

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

        public async Task Add(ETask entity)
        {
            throw new System.NotImplementedException();
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