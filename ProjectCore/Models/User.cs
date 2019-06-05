using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ProjectCore.Models
{
    public class User : IdentityUser
    {   
        public bool IsActive { get; set; }
    }
}