namespace ProjectCore.Models
{
    public class Task : Entity
    {
        public string name { get; set; }
        public string description { get; set; }
        public TaskType type { get; set; }
        public User reporter { get; set; }
        public User assignee { get; set; }
        public int state { get; set; }
    }
}