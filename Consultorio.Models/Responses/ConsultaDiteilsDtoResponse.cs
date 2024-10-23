using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Responses
{
    public class ConsultaDiteilsDtoResponse : EntityBaseDtoResponse
    {
        public DateTime ScheduleDay { get; set; }
        public DateTime BeginingScheduleHour { get; set; }
        public DateTime EndingScheduleHour { get; set; }
        public DateTime Appoinmentlength { get; set; }
        public PractitionerDetailsDtoResponse Practitioner { get; set; } = default!;
        public PatientDiteilsDtoResposne Patient { get; set; } = default!;
        public ConsultorioDiteilsDtoRepsosne Consultorio { get; set; } = default!;
    }
}
