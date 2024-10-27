using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class ResetPasswordDtoRequest
    {
        [Required]
        public string Token { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string ResetNewPassword { get; set; } = default!;
        [Compare(nameof(ResetNewPassword))]
        public string ConfirmNewPassword { get; set; } = default!;

    }
}
