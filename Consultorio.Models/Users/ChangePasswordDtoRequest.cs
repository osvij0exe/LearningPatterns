using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class ChangePasswordDtoRequest
    {

        public string CurrentPassword { get; set; } = default!;
        [Required]
        public string NewPassword { get; set; } = default!;
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; } = default!;

    }
}
