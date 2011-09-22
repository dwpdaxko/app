using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.utility.containers
{
    public class DependencyFactoryRegistry : IFindDependencyFactories
    {
        IDictionary<IRepresentAType, ICreateADependency> factories;
        ICreateADependency missing_dependency_factory;

        public DependencyFactoryRegistry(IDictionary<IRepresentAType, ICreateADependency> factories,
                                         ICreateADependency missing_dependency_factory)
        {
            this.factories = factories;
            this.missing_dependency_factory = missing_dependency_factory;
        }

        public ICreateADependency find_factory_for(Type dependency_type)
        {
            var key = get_the_key_for(dependency_type);
            return key != null ? factories[key] :missing_dependency_factory ;
        }

        IRepresentAType get_the_key_for(Type dependency_type)
        {
            return factories.Keys.FirstOrDefault(x => x.represents(dependency_type));
        }
    }
}