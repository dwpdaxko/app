using System;

namespace nothinbutdotnetstore.utility.containers
{
    public class Container : IFetchDependencies
    {
        IFindDependencyFactories dependency_factories;

        public Container(IFindDependencyFactories dependency_factories)
        {
            this.dependency_factories = dependency_factories;
        }

        public Dependency a<Dependency>()
        {
            return (Dependency) a(typeof(Dependency));
        }

        public object a(Type dependency_type)
        {
            try
            {
                return dependency_factories.factory_for(dependency_type).create();
            }
            catch (Exception e)
            {
                throw new DependencyCreationException(e,dependency_type);
            }
        }
    }
}