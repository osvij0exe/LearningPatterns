using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Entities
{
    public class Consulta : EntityBase
    {
        public DateTime ScheduleDay { get; set; }
        public DateTime BeginingScheduleHour { get; set; }
        public DateTime EndingScheduleHour { get; set; }
        public Guid PractitionerId { get; set; }
        public Practitioner Practitioner { get; set; } = default!;
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; } = default!;
        public Guid ConsultorioId { get; set; }
        public ConsultorioEntity Consultorio { get; set; } = default!;
    }
}
