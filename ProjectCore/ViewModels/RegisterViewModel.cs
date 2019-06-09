using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Models
{
    public class RegisterViewModel
    {
        [Required, MinLength(3), MaxLength(24)]
        public string UserName { get; set; }
        [Required, MinLength(6), MaxLength(24), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}