using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Request
{
    public class ConsultaDtoRequest
    {
        public DateTime BeginingScheduleHour { get; set; }
        public DateTime Appoinmentlength { get; set; }
        public Guid PractitionerId { get; set; }
        public Guid PatientId { get; set; }
        public Guid ConsultorioId { get; set; }

    }




}
