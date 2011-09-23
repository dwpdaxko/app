using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class QueryForSpecs
    {
        public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                            QueryFor<IEnumerable<Product>,SomeQuery>>
        {
        }

        public class when_run : concern
        {
            Establish context = () =>
            {
                products = new List<Product> {new Product()};
                display_engine = depends.on<IDisplayReports>();
                query = new SomeQuery(products);
                depends.on(query);

                request = fake.an<IContainRequestInformation>();

            };

            Because b = () => sut.process(request);

            It should_display_the_items_found_using_the_query =
                () => display_engine.received(x => x.display(products));

            static IDisplayReports display_engine;
            static IEnumerable<Product> products;
            static IContainRequestInformation request;
            static SomeQuery query;
        }
    }

    public class SomeQuery :IFetchA<IEnumerable<Product>>
    {
        IEnumerable<Product> products;

        public SomeQuery(IEnumerable<Product> products)
        {
            this.products = products;
        }

        public IEnumerable<Product> run_using(IContainRequestInformation request)
        {
            return products;
        }
    }
}