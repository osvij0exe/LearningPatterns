using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Users
{
    public class GenerateTokenToDtoRequest
    {
        public string Usuario { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
