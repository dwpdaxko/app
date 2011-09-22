namespace nothinbutdotnetstore.utility.containers
{
    public class Container : IFetchDependencies
    {
        IFindTypeFactories dependency_factories;

        public Container(IFindTypeFactories dependency_factories)
        {
            this.dependency_factories = dependency_factories;
        }

        public Dependency a<Dependency>()
        {
            dependency_factories.factory_for<Dependency>();

            return default(Dependency);
        }
    }
}