using Consultorio.DataAccess;
using Consultorio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.UnitOfWork.Implementation
{
    public class ConsultorioUnitOfWork : UnitOfWork
    {
        private readonly ApplicationDbContext Context;

        public ConsultorioUnitOfWork(ApplicationDbContext context,
            IConsultorioRespository consultorioRespository) 
            : base(context)
        {
            Context = context;
            ConsultorioRespository = consultorioRespository;
        }

        public IConsultorioRespository ConsultorioRespository { get; } 
    }
}
