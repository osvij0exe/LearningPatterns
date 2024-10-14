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

        public static readonly Error NotFound = new("Practitioner.NotFound","The practitoner was not found");
        public static readonly Error Exception = new("Practitioner.Exception","An error ocurred");
        //Agregar pas errores 

    }
}
