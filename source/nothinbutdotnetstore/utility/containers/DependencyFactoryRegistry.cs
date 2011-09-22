using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.utility.containers
{
    public class DependencyFactoryRegistry : IFindDependencyFactories
    {
        IEnumerable<ICreateADependency> factories;

        public DependencyFactoryRegistry(IEnumerable<ICreateADependency> factories)
        {
            this.factories = factories;
        }

        public ICreateADependency find_factory_for(Type dependency_type)
        {
            return factories.First(x => x.can_create(dependency_type));
        }
    }
}