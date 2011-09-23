using System;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.simple;

namespace nothinbutdotnetstore.tasks
{
    public class Startup
    {
        static IDictionary<IRepresentAType, ICreateADependency> factories;

        public static void run()
        {
            factories = new Dictionary<IRepresentAType, ICreateADependency>();

            var container =
                new Container(new DependencyFactoryRegistry(factories, type => new SimpleDependencyFactory(delegate
                {
                    throw new NotImplementedException(string.Format("Failed to create an instance of {0}", type.Name));
                })));

            Depends.container_resolver = () => container;

            populate_factories();
        }

        static void populate_factories()
        {
        }
    }
}