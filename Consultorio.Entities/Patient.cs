using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Entities
{
    public class Patient : EntityBase
    {
        public string GivenName { get; set; } = default!;
        public string FamilyName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public List<Consulta> Consultas { get; set; } = default!;
    }
}
