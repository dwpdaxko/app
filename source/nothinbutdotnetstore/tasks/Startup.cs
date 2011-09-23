using System;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.simple;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks
{
    public class Startup
    {
        static IDictionary<IRepresentAType, ICreateADependency> factories;

        public static void run()
        {
            factories  = new Dictionary<IRepresentAType, ICreateADependency>();

            var container = new Container(new DependencyFactoryRegistry(factories, new SimpleDependencyFactory(delegate
            {
                throw new NotImplementedException("Failed to create an instance");
            })));

            Depends.container_resolver = () => container;

            populate_factories();
        }

        static void populate_factories()
        {
            factories.Add(null,new SimpleDependencyFactory(() => new FrontController()));
        }
    }
}