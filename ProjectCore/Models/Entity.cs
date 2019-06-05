using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCore.Models
{
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public long Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfUpdate { get; set; }
    }
}