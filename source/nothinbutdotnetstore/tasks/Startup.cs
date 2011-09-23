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
            factories.Add(new SimpleTypeKey((typeof(IFindCommands))), new SimpleDependencyFactory(() => new StubCommandRegistry()));
            factories.Add(new SimpleTypeKey(typeof(IProcessRequests)), new SimpleDependencyFactory(() => new FrontController(Depends.on.a<IFindCommands>())));
        }
    }

    internal class StubCommandRegistry : IFindCommands
    {
        public IProcessOneRequest get_the_command_that_can_process(IContainRequestInformation request)
        {
            throw new NotImplementedException();
        }
    }
}