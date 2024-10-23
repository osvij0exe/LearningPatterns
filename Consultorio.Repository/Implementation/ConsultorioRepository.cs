using Consultorio.DataAccess;
using Consultorio.Entities;
using Consultorio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Implementation
{
    public class ConsultorioRepository : RepositoryBase<ConsultorioEntity>, IConsultorioRespository
    {
        public ConsultorioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
