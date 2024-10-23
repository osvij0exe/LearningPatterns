using Consultorio.Entities;
using Consultorio.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Helpers
{
    public static class AppoinmentsHelpers
    {
        public static DateTime EndingScheduleHour(DateTime beginingScheduleHour, DateTime Appoinmentlength)
        {

            var hours = Appoinmentlength.Hour;
            var minutes = Appoinmentlength.Minute;
            var endingScheduleHour = beginingScheduleHour
                .AddHours(hours)
                .AddMinutes(minutes);
            return endingScheduleHour;
        }

        public static (bool,Consulta) OverlappingSchedule(ICollection<Consulta> consultas,ConsultaDtoRequest currentConsulta)
        {
            var inicioConsultaActual = currentConsulta.BeginingScheduleHour;
            
            var totalDeHorasConsultaActual = currentConsulta.Appoinmentlength.Hour;
            var totalDeMinutosConsultaActual = currentConsulta.Appoinmentlength.Minute;

            var finConsultaActual = currentConsulta.BeginingScheduleHour
                .AddHours(totalDeHorasConsultaActual)
                .AddMinutes(totalDeMinutosConsultaActual);           

            foreach (var consulta in consultas)
            {

                if(consulta.BeginingScheduleHour > inicioConsultaActual && consulta.BeginingScheduleHour  < finConsultaActual)
                {
                    return (true, consulta);
                }

                var consultaHoras = consulta.Appoinmentlength.Hour;
                var consultaMinutos = consulta.Appoinmentlength.Minute;
                var finConsulta = consulta.EndingScheduleHour;
                if(finConsulta > inicioConsultaActual && finConsulta < finConsultaActual)
                {
                    return (true,consulta);
                } 

            }

            return (false,new Consulta());
        }
    }
}
