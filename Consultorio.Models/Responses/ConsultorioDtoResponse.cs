using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Responses
{
    public class ConsultorioDtoResponse : EntityBaseDtoResponse
    {
        public int MedicalOficceNumber { get; set; }
        public string Speciality { get; set; } = default!;
    }
}
