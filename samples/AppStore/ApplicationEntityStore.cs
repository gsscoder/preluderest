using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStore.Model;
using CSharpx;
using PreludeRest.Data;

namespace AppStore
{
    public class ApplicationEntityStore : IEntityStore<Application>
    {
        static readonly IList<Application> _applications = new List<Application>()
            {
                new Application() { Id = "app_gKnF0kVZyI7gVD1x5eG1", Name = "Google Maps" },
                new Application() { Id = "app_jbwJBtdk7sT9s6sMk330", Name = "Tinder" },
                new Application() { Id = "app_3m9VHfHT5G51CQ7LWPaU", Name = "TikTok" },
                new Application() { Id = "app_kYSBiVh4Qp7DD8D3H5w2", Name = "Space Ace" },
                new Application() { Id = "app_IvRBWUnO9zncKrpvZJCg", Name = "WhatsApp" },
                new Application() { Id = "app_c2P038lOZC40S8OzE2aB", Name = "Pixlr" },
                new Application() { Id = "app_TaXqAcNFblfSVxNQtnnh", Name = "Foodie" },
                new Application() { Id = "app_aa15dxUMdeZD9RcV3IQ7", Name = "Facebook" }
            };

        public Task<IEnumerable<Application>> GetAsync() =>
            Task.FromResult((IEnumerable<Application>)_applications);

        public Task<IEnumerable<Application>> GetAsync(Func<Application, bool> predicate) =>
            Task.FromResult(_applications.Where(predicate));

        public Task<Application> GetByIdAsync(string id) =>
            Task.FromResult(_applications.SingleOrDefault(a => a.Id == id));

        public Task<IEnumerable<Application>> GetBySearchTextAsync(string value) =>
            Task.FromResult(_applications.Where(a => a.Name.Contains(value, StringComparison.OrdinalIgnoreCase)));


        public Task<string> InsertAsync(Application entity)
        {
            var newId = $"app_{StringUtil.Generate(20)}";
            entity.Id = newId;
            _applications.Add(entity);
            return Task.FromResult(newId);
        }

        public Task<bool> UpdateAsync(Application entity)
        {
            var item = _applications.SingleOrDefault(a => a.Id == entity.Id);
            if (item == null) return Task.FromResult(false);
            item.Name = entity.Name;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var item = _applications.SingleOrDefault(a => a.Id == id);
            if (item == null) return Task.FromResult(false);
            return Task.FromResult(_applications.Remove(item));
        }
    }
}
