using Consultorio.DataAccess;
using Consultorio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.UnitOfWork.Interfaces
{
    public class PractitionerUnitOfWork : UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public PractitionerUnitOfWork(ApplicationDbContext context,
            IPractitionerRepository practitionerRepository) 
            : base(context)
        {
            _context = context;
            PractitionerRepository = practitionerRepository;
        }

        public IPractitionerRepository PractitionerRepository { get; }
    }
}
