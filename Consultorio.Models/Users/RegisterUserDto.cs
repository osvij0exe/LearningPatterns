using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class RegisterUserDto
    {
        [Required]
        public string Usuario { get; set; } = default!;
        [Required]
        public string GivenName { get; set; } = default!;
        [Required] 
        public string FamilyName { get; set; } = default!;
        [Required] 
        public string Email { get; set; } = default!;

        [Required] 
        public string PhoneNumber { get; set; } = default!;
        [Required] 
        public string Password { get; set; } = default!;
        [Required]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password),ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; } = default!;
        public string UserRoleId { get; set; } = default!;
    }
}
