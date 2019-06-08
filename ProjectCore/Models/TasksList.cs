using System.Collections.Generic;

namespace ProjectCore.Models
{
    public class TasksList
    {
        public TasksList(IEnumerable<Task> list)
        {
            _tasksList = list;
        }
        
        public IEnumerable<Task> _tasksList { get; set; }
    }
}