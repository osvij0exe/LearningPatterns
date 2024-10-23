using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Responses
{
    public class ConsultaDiteilsDtoResponse : EntityBaseDtoResponse
    {
        public string ScheduleDay { get; set; } = default!;
        public string BeginingScheduleHour { get; set; } = default!;
        public string EndingScheduleHour { get; set; } = default!;
        public string Appoinmentlength { get; set; } = default!;
        public PractitionerDetailsDtoResponse Practitioner { get; set; } = default!;
        public PatientDiteilsDtoResposne Patient { get; set; } = default!;
        public ConsultorioDiteilsDtoRepsosne Consultorio { get; set; } = default!;

        public ConsultaDiteilsDtoResponse(DateTime scheduleDay,DateTime beginingScheduleHour,DateTime endingScheduleHour, DateTime appoinmentlength)
        {
            ScheduleDay = scheduleDay.ToString("d");
            BeginingScheduleHour = beginingScheduleHour.ToString("HH:mm tt");
            EndingScheduleHour = endingScheduleHour.ToString("HH:mm tt");
            Appoinmentlength = appoinmentlength.ToString("HH:mm tt");
        }

    }
}
