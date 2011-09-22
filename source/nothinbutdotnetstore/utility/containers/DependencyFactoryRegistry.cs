using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.utility.containers
{
    public class DependencyFactoryRegistry : IFindDependencyFactories
    {
        IDictionary<IRepresentAType,ICreateADependency> factories;

        public DependencyFactoryRegistry(IDictionary<IRepresentAType, ICreateADependency> factories)
        {
            this.factories = factories;
        }

        public ICreateADependency find_factory_for(Type dependency_type)
        {
            return factories[get_the_key_for(dependency_type)];
        }

        IRepresentAType get_the_key_for(Type dependency_type)
        {
            return factories.Keys.First(x => x.represents(dependency_type));
        }
    }
}