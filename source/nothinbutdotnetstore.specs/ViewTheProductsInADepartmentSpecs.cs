using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof (ViewTheProductsInADepartment))]
    public class ViewTheProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                            BrowseTheStore<ViewTheProductsInADepartmentInputModel, IEnumerable<Product>>>
        {
        }

        public class when_run : concern
        {

            Establish context = () =>
                {
                    display_engine = depends.on<IDisplayReports>();
                    request = fake.an<IContainRequestInformation>();

                    product_repository = depends.on<IRetrieveStoreInformation>();
                    view_products_command = fake.an<ViewTheProductsInADepartmentInputModel>();
                    
                    products = new List<Product> { new Product() };

                    request.setup(x => x.map_a<ViewTheProductsInADepartmentInputModel>())
                        .Return(view_products_command);

                    product_repository.setup(x => x.get_items_for<ViewTheProductsInADepartmentInputModel, IEnumerable<Product>>(view_products_command))
                        .Return(products);
                };

            Because b = () => sut.process(request);

            It should_display_a_list_of_products_for_the_specified_department = 
                () => display_engine.received(x => x.display(products));

            static IDisplayReports display_engine;
            static IEnumerable<Product> products;
            static IContainRequestInformation request;
            static IRetrieveStoreInformation product_repository;
            static ViewTheProductsInADepartmentInputModel view_products_command;
        }
    }
}