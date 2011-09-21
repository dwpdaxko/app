using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheProductsInADepartment))]
    public class QueryForSpecs
    {
        public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                            QueryFor<IEnumerable<Product>>>
        {
        }

        public class when_run : concern
        {
            Establish context = () =>
            {
                display_engine = depends.on<IDisplayReports>();
                query = depends.on<IFetchA<IEnumerable<Product>>>();
                request = fake.an<IContainRequestInformation>();

                products = new List<Product> {new Product()};

                query.setup(x => x.run_using(request)).Return(products);
            };

            Because b = () => sut.process(request);

            It should_display_the_items_found_using_the_query =
                () => display_engine.received(x => x.display(products));

            static IDisplayReports display_engine;
            static IEnumerable<Product> products;
            static IContainRequestInformation request;
            static IFetchA<IEnumerable<Product>> query;
        }
    }
}