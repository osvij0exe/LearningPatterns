using Consultorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Helpers
{
    public static class PatientHelper
    {
        public static int GetPatientAge(DateTime birthDate)
        {
            var FechaActual = DateTimeOffset.UtcNow;
            var edad = FechaActual.Year - birthDate.Date.Year;
            // restamos las fechas no solamente los años para que nos de un resultado mas exacto
            //ojo ten en cuenta la zona horaria o va  a dar error por las horas
            if(birthDate.Date > FechaActual.Date.AddYears(- edad))
            {
                // si la fecha que viene en el paciente es mayor a la fecha actual restandole los años
                // se le resta uno para obtener los años reales
                edad = edad - 1;
            }
            return edad;
        }


    }
}
