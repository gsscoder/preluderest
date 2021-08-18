using PreludeRest.Data;

namespace AppStore.Model
{
    public class Application : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
