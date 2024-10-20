using Consultorio.Entities.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Errors
{
    public static class PatientErrors
    {

        public static Error NotFound(Guid id) => Error.NotFound(code: "Patient.NotFound", description: $"The patient with the id: {id} was not found");
    }
}
