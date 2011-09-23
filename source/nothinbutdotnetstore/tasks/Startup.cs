using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.simple;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.link_builder;
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
            register<ICreateLinkBuilders>(()=>new LinkBuilderFactory(new TokenStore(), Depends.on.a<IProcessAToken>()));
            register<IFetchDependencies>(()=> Depends.on);
            register<GetTheCurrentlyExecutingContext>(()=>HttpContext.Current);
            register<IFindMappers>(()=>new MapperRegistry(Depends.on.a<IFetchDependencies>()));
            register<IFindPathsToViews>(() => Stub.with<StubViewPathRegistry>());
            register<IFindViewForModel>(() => new WebFormViewRegistry(BuildManager.CreateInstanceFromVirtualPath, Depends.on.a<IFindPathsToViews>()));
            register<IDisplayReports>(() => new WebFormDisplayEngine(Depends.on.a<IFindViewForModel>(), () => HttpContext.Current));
            register<ICreateRequests>(() => new RequestFactory(Depends.on.a<IFindMappers>()));
            register<IProcessRequests>(() => new FrontController(Depends.on.a<IFindCommands>()));
            register<IFindCommands>(() => new CommandRegistry(
                Depends.on.a<IEnumerable<IProcessOneRequest>>(),
                Depends.on.a<IProcessOneRequest>()));
            register<IOrchestrateAnApplicationFeature>(()=> new OrchestrateAnApplicationFeature() );
            register<IEnumerable<IProcessOneRequest>>(() => Stub.with<StubSetOfCommands>());
            register<IProcessOneRequest>(() => Stub.with<StubMissingCommand>());
            register<IProcessAToken>(()=>new LinkVisitor());
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
}
