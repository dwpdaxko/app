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
        static IFetchDependencies container;

        public static void run()
        {
            factories = new Dictionary<IRepresentAType, ICreateADependency>();

            container =
                new Container(new DependencyFactoryRegistry(factories, type => new SimpleDependencyFactory(delegate
                {
                    throw new NotImplementedException(string.Format("Failed to create an instance of {0}", type.Name));
                })));

            Depends.container_resolver = () => container;

            populate_factories();
        }

        static void populate_factories()
        {
            register(container);
            register<ICreateLinkBuilders, LinkBuilderFactory>();
            register<GetTheCurrentlyExecutingContext>(() => HttpContext.Current);
            register<WebFormFactory>(BuildManager.CreateInstanceFromVirtualPath);
            register<IFindMappers, MapperRegistry>();
            register<IFindPathsToViews, StubViewPathRegistry>();
            register<IFindViewForModel, WebFormViewRegistry>();
            register<IDisplayReports, WebFormDisplayEngine>();

            register<ICreateRequests, RequestFactory>();
            register<IProcessRequests, FrontController>();
            register<IFindCommands, CommandRegistry>();
            register<IEnumerable<IProcessOneRequest>, StubSetOfCommands>();
            register<IProcessOneRequest, StubMissingCommand>();
            register<IProcessAToken, LinkVisitor>();

            register<IMapAnInputModelOf<ViewMainDepartmentsRequest>, StubInputModelMapper<ViewMainDepartmentsRequest>>();
            register<IMapAnInputModelOf<ViewTheDepartmentsOfADepartmentRequest>,
                    StubInputModelMapper<ViewTheDepartmentsOfADepartmentRequest>>();
            register<IMapAnInputModelOf<ViewTheProductsInADepartmentRequest>,
                    StubInputModelMapper<ViewTheProductsInADepartmentRequest>>();

            register<StubGetTheDepartmentsInADepartment>();
            register<StubGetTheMainDepartments>();
            register<StubGetTheProductsInADepartment>();

            register_query<StubGetTheMainDepartments, IEnumerable<Department>>();
            register_query<StubGetTheDepartmentsInADepartment, IEnumerable<Department>>();
            register_query<StubGetTheProductsInADepartment, IEnumerable<Product>>();
        }

        static void register_query<QueryObject, ReportModel>() where QueryObject : IFetchA<ReportModel>
        {
            register<QueryFor<ReportModel, QueryObject>>();
        }

        static void register<Implementation>()
        {
            register<Implementation, Implementation>();
        }

        static void register<Contract, Implementation>()
        {
            factories.Add(new SimpleTypeKey(typeof(Contract)),
                          new AutomaticDependencyFactory(Depends.on.a<IFetchDependencies>(),
                                                         new GreediestConstructorPicker(),
                                                         typeof(Implementation)));
        }

        static void register<Contract>(Contract implementation)
        {
            factories.Add(new SimpleTypeKey(typeof(Contract)), new
                                                                   SimpleDependencyFactory(() => implementation));
        }
    }
}