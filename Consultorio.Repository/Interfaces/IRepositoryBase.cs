using Consultorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<ICollection<TEntity>> ListAsync();
        Task<TEntity?> FindByIdAsync(Guid id);
        Task<TEntity?> FindByIdAsNoTrackingAsync(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);   
        void Delete(TEntity entity);

        Task Reactive(Guid id);
        Task LogicDelete(Guid id);

        Task SavechangesAsync();
    }
}
