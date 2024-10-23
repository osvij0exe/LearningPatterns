using Consultorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Interfaces
{
    public interface IConsultaRepository : IRepositoryBase<Consulta>
    {
        Task<ICollection<Consulta>> GetApoinments();
        Task<ICollection<Consulta>> GetConsultorioApoinments(Guid consultorioId);
        Task<ICollection<Consulta>> GetPatientApoinments(Guid patientiId);
        Task<ICollection<Consulta>> GetPractitionerApoinments(Guid practitionerId);


    }

    
}
