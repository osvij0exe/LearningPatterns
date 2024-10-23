using Consultorio.Entities.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Errors
{
    public class ConsultorioErrors
    {
        public static Error NotFound(Guid id) => Error.NotFound(code: "Consultorio.NotFound", description: $"The consultorio with the id: {id} was not found");


    }
}
