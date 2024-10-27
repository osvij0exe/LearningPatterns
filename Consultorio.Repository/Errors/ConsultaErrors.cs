using Consultorio.Entities;
using Consultorio.Entities.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Errors
{
    public static class ConsultaErrors
    {
        public static Error NotFound(Guid id) => Error.NotFound(code: "Consulta.NotFound", description: $"The apoinmment with the id : {id} was not found");
        public static Error ScheduleTimeConflict(DateTime beginingScheduleHour, DateTime endingScheduleHour, int consultorio) =>
            Error.Conflict(code: "Consulta.Conflict", 
                description: $"The scheadulte it's all ready occupied from: {beginingScheduleHour} to : {endingScheduleHour} in the MedicalOficceNumber : {consultorio}");
        public static Error PatientApoinmmetnsConflict(DateTime beginingScheduleHour, DateTime endingScheduleHour, int consultorio) =>
                        Error.Conflict(code: "Consulta.Conflict",
                description: $"The patient has an other Appoiment from: {beginingScheduleHour} to : {endingScheduleHour} in the MedicalOficceNumber : {consultorio}");
        public static Error PractitionerApoinmmetnsConflict(DateTime beginingScheduleHour, DateTime endingScheduleHour, int consultorio) =>
                Error.Conflict(code: "Consulta.Conflict",
        description: $"The practitioner has an other Appoiment from: {beginingScheduleHour} to : {endingScheduleHour} in the MedicalOficceNumber : {consultorio}");

        public static Error ConsultorioApoinmmetnsConflict(DateTime beginingScheduleHour, DateTime endingScheduleHour) =>
        Error.Conflict(code: "Consulta.Conflict",
description: $"The medical oficce has an other Appoiment from: {beginingScheduleHour} to : {endingScheduleHour}");

    }
}
