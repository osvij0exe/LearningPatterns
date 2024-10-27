using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.DataAccess.Users
{
    public class ConsultorioUser: IdentityUser
    {
        [StringLength(250)]
        public string GivenName { get; set; } = default!;
        [StringLength(250)]
        public string FamilyName { get; set; } = default!;
    }
}
