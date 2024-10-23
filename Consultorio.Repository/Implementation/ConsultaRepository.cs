using Consultorio.DataAccess;
using Consultorio.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Implementation
{
    public class ConsultaRepository : RepositoryBase<Consulta>, IConsultaRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Consulta>> GetApoinments()
        {
            var apoinments = await _context.Set<Consulta>()
                .Include(c => c.Practitioner)
                .Include(c => c.Patient)
                .Include(c => c.Consultorio)
                .ToArrayAsync();
            return apoinments;
        }

        public async Task<ICollection<Consulta>> GetConsultorioApoinments(Guid consultorioId)
        {
            var apponments = await _context.Set<Consulta>()
                .Where(c => c.ConsultorioId == consultorioId)
                .Include(c => c.Consultorio)
                .Include(c => c.Patient)
                .Include(c => c.Practitioner)
                .ToListAsync();
            return apponments;
        }

        public async Task<ICollection<Consulta>> GetPatientApoinments(Guid patientiId)
        {
            var appoinments = await _context.Set<Consulta>()
                .Where(c => c.PatientId == patientiId)
                .Include(c => c.Consultorio)
                .Include(c => c.Patient)
                .Include(c => c.Practitioner)
                .ToListAsync();
            
            return appoinments;
        }

        public async Task<ICollection<Consulta>> GetPractitionerApoinments(Guid practitionerId)
        {
            var apponments = await _context.Set<Consulta>()
                .Where(c => c.PractitionerId == practitionerId)
                .Include(c => c.Consultorio)
                .Include(c =>c.Patient)
                .Include(c => c.Practitioner)
                .ToListAsync();
            return apponments;
        }
    }
}
