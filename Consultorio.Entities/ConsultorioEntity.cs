using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Entities
{
    public class ConsultorioEntity : EntityBase
    {
        public int MedicalOficceNumber { get; set; }
        public string Speciality { get; set; } = default!;
        public List<Consulta> Consultas { get; set; } = default!;

    }
}
