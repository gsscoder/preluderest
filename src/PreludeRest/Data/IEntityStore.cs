using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreludeRest.Data
{
    public interface IEntityStore<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);

        Task<TEntity> GetByIdAsync(string id);

        Task<IEnumerable<TEntity>> GetBySearchTextAsync(string value);

        Task<string> InsertAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(string id);
    }
}
