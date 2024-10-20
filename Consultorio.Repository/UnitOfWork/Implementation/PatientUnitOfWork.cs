using Consultorio.DataAccess;
using Consultorio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.UnitOfWork.Implementation
{
    public class PatientUnitOfWork : UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public PatientUnitOfWork(ApplicationDbContext context,
            IPatientRepository patientRepository) 
            : base(context)
        {
            _context = context;
            PatientRepository = patientRepository;

        }

        public IPatientRepository PatientRepository { get;}
    }
}
