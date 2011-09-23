using System;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.simple;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

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
            register<IProcessRequests>(() => new FrontController(Depends.on.a<IFindCommands>()));

            register<IFindCommands>(() => new CommandRegistry(
                Depends.on.a<IEnumerable<IProcessOneRequest>>(),
                Depends.on.a<IProcessOneRequest>()));

            register<IEnumerable<IProcessOneRequest>>(() => Stub.with<StubSetOfCommands>());

            register<IMapAnInputModelOf<ViewMainDepartmentsRequest>>(() => new StubInputModelMapper<ViewMainDepartmentsRequest>());
            register<IMapAnInputModelOf<ViewTheDepartmentsOfADepartmentRequest>>(() => new StubInputModelMapper<ViewTheDepartmentsOfADepartmentRequest>());
            register<IMapAnInputModelOf<ViewTheProductsInADepartmentRequest>>(() => new StubInputModelMapper<ViewTheProductsInADepartmentRequest>());
        }

        static void register<Contract>(Func<object> implementation)
        {
            factories.Add(new SimpleTypeKey(typeof(Contract)), new
                                                                   SimpleDependencyFactory(implementation));
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