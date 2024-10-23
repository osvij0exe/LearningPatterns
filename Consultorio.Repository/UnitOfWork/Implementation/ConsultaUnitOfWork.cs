using Consultorio.DataAccess;
using Consultorio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.UnitOfWork.Implementation
{
    public class ConsultaUnitOfWork : UnitOfWork
    {
        private readonly ApplicationDbContext Context;

        public ConsultaUnitOfWork(ApplicationDbContext context,
            IConsultaRepository consultaRepository,
            IPatientRepository patientRepository,
            IPractitionerRepository practitionerRepository,
            IConsultorioRespository consultorioRespository
            ) : 
            base(context)
        {
            Context = context;
            ConsultaRepository = consultaRepository;
            PatientRepository = patientRepository;
            PractitionerRepository = practitionerRepository;
            ConsultorioRespository = consultorioRespository;
        }

        public IConsultaRepository ConsultaRepository { get; }
        public IPatientRepository PatientRepository { get; }
        public IPractitionerRepository PractitionerRepository { get; }
        public IConsultorioRespository ConsultorioRespository { get; }
    }
}
