using AppStore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PreludeRest;
using PreludeRest.Data;

namespace AppStore.Controllers
{
    [ApiController]
    [Route("applications")]
    public class ApplicationController : EntityControllerBase<Application>
    {
        public ApplicationController(ILogger<IEntityStore<Application>> logger, IEntityStore<Application> store) : base(logger, store)
        {
        }

        [HttpGet]
        public override async Task<IEnumerable<Application>> GetAsync() => await base.GetAsync();

        [HttpGet("{id}")]
        public override async Task<Application> GetByIdAsync(string id) => await base.GetByIdAsync(id);

        [HttpGet("search/{text}")]
        public override async Task<IEnumerable<Application>> GetBySearchTextAsync(string text) =>
            await base.GetBySearchTextAsync(text);

        [HttpPost]
        public override async Task<IActionResult> InsertAsync(Application application) => await base.InsertAsync(application);

        [HttpPut]
        public override async Task<IActionResult> UpdateAsync(Application application) => await base.UpdateAsync(application);

        [HttpDelete("{id}")]
        public override async Task<IActionResult> DeleteAsync(string id) => await base.DeleteAsync(id);
    }
}
