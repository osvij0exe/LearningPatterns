using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Entities
{
    public class Practitioner : EntityBase
    {
        public string GivenName { get; set; } = default!;
        public string FamilyName { get; set; } = default!;
        public string Qualification { get; set; } = default!;
        public List<Consulta> Consultas { get; set; } = default!;
    }
}
