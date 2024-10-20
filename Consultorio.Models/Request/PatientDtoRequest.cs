using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Request
{
    public class PatientDtoRequest
    {
        public string GivenName { get; set; } = default!;
        public string FamilyName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
    }
}
