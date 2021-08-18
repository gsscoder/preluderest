using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PreludeRest.Data;

namespace PreludeRest
{
    public abstract class EntityControllerBase<TEntity> : ControllerBase where TEntity : IEntity
    {
        readonly ILogger<IEntityStore<TEntity>> _logger;
        protected IEntityStore<TEntity> Store { get; private set; }

        public EntityControllerBase(ILogger<IEntityStore<TEntity>> logger, IEntityStore<TEntity> store)
        {
            _logger = logger;
            Store = store;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await Store.GetAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate) => await Store.GetAsync(predicate);

        public virtual async Task<TEntity> GetByIdAsync(string id) => await Store.GetByIdAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetBySearchTextAsync(string value) => await Store.GetBySearchTextAsync(value);

        public virtual async Task<IActionResult> InsertAsync(TEntity entity)
        {
            var newId = await Store.InsertAsync(entity);
            return newId == null
                ? Problem($"Unable to insert entity with ID {newId}")
                : new OkObjectResult(new { Id = newId });
        }

        public virtual async Task<IActionResult> UpdateAsync(TEntity entity)
        {
            var success = await Store.UpdateAsync(entity);
            return success
                ? new NoContentResult()
                : Problem($"Unable to update entity with ID {entity.Id}");
        }

        public virtual async Task<IActionResult> DeleteAsync(string id)
        {
            var success = await Store.DeleteAsync(id);
            return success
                ? new NoContentResult()
                : Problem($"Unable to delete entity with ID {id}");
        }

        IActionResult Problem(string message)
        {
            _logger.LogCritical(message);
            return StatusCode(StatusCodes.Status500InternalServerError, new { mesaage = message });
        }
    }
}
