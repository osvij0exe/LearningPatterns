using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class LoginDtoRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
    }
}
