using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Models
{
    public class TaskEditViewModel
    {
        [Required]
        public string name { get; set; }
        
        [Required]
        public string description { get; set; }
        
        [Required]
        public int type { get; set; }
        
        [Required]
        public string assignee { get; set; }
        
        [Required]
        public int state { get; set; }
    }
}