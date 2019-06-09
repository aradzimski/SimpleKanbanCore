using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Context;
using ProjectCore.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectCore.Repositories
{
    public class TaskTypeRepository
    {
        private readonly ProjectCoreContext _projectCoreContext;
        
        public TaskTypeRepository(ProjectCoreContext projectCoreContext)
        {
            _projectCoreContext = projectCoreContext;
        }
        public async Task<IEnumerable<TaskType>> GetAll()
        {
            var result = await _projectCoreContext.TaskType.ToListAsync();
            return result;
        }
        
        public async Task<TaskType> GetById(long id)
        {
            var result = await _projectCoreContext.TaskType
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            return result;
        }
    }
}