using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.web.core
{
    public class MapperRegistry : IFindMappers
    {
        IFetchDependencies container;

        public MapperRegistry(IFetchDependencies container)
        {
            this.container = container;
        }

        public IMapDetails<Input, Output> get_mapper_that_can_map<Input, Output>()
        {
            return container.a<IMapDetails<Input, Output>>();
        }
    }
}