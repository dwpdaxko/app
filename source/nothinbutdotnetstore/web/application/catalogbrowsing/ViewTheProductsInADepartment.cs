using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheProductsInADepartment : IOrchestrateAnApplicationFeature
    {
        IDisplayReports display_engine;
        IRetrieveStoreInformation product_repository;

        public ViewTheProductsInADepartment(IDisplayReports display_engine, IRetrieveStoreInformation product_repository)
        {
            this.display_engine = display_engine;
            this.product_repository = product_repository;
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(product_repository.get_products_for(request.map_a<ViewTheProductsInADepartmentInputModel>()));
        }
    }
}