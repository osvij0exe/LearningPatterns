using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Request
{
    public class PractitionerDtoRequest 
    {
        [Required]
        public string GivenName { get; set; } = default!;
        public string FamilyName { get; set; } = default!;
        public string Qualification { get; set; } = default!;
    }
}
