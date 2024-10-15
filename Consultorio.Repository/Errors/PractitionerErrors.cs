using Consultorio.Entities.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Errors
{
    public static class PractitionerErrors
    {

        /*
         ejemplo de ocmo se implementa lalmando al constructor
         */
        //public static readonly Error NotFound = new(code:"Practitioner.NotFound",description:"The practitoner was not found",errorType:ErrorType.NotFound);
        //public static readonly Error Exception = new(code:"Practitioner.Exception",description:"An error ocurred", errorType: ErrorType.Exception);
        //Agregar pas errores 

        // Dependiendo de el erro es el que se encvia ya sea de conflicto, de validacion, etc

        public static Error NotFound(Guid id) => Error.NotFound(code:"Practitioner.NotFound",description:$"The practitoner with the id: {id} was not found");
        public static readonly Error Exception = Error.Exception(code:"Practitioner.NotFound",description:"The practitoner was not found");

    }
}
