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
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

        }

        public void Delete(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity?> FindByIdAsNoTrackingAsync(Guid id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
            
        }

        public async Task<TEntity?> FindByIdAsync(Guid id)
        {

            return await _context.Set<TEntity>().FindAsync(id);  
        }

        public async Task<ICollection<TEntity>> ListAsync()
        {
            

            return await _context.Set<TEntity>()
                .Where(t => t.Active == true)
                .ToListAsync();
        }

        public async Task LogicDelete(Guid id)
        {
            var registro = await _context.Set<TEntity>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(t => t.Id == id);
            registro!.Active = false;
        }

        public async Task Reactive(Guid id)
        {
            var registro = await  _context.Set<TEntity>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(t => t.Id == id);
            registro!.Active = true;

        }

        public async Task SavechangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public  void Update(TEntity entity){ /*code no required*/}
    }
}
