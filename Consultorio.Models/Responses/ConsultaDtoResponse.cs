using Consultorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Responses
{
    public class ConsultaDtoResponse : EntityBaseDtoResponse
    {
        public DateTime ScheduleDay { get; set; }
        public DateTime BeginingScheduleHour { get; set; }
        public DateTime EndingScheduleHour { get; set; }
        public DateTime Appoinmentlength { get; set; }
        public Guid PractitionerId { get; set; }
        public PractitionerDtoResponse Practitioner { get; set; } = default!;
        public Guid PatientId { get; set; }
        public PatientDtoResponse Patient { get; set; } = default!;
        public Guid ConsultorioId { get; set; }
        public ConsultorioDtoResponse Consultorio { get; set; } = default!;
    }
}
