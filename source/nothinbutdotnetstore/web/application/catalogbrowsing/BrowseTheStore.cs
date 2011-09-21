using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class BrowseTheStore<InputModel, OutputModel> : IOrchestrateAnApplicationFeature
    {
        IRetrieveStoreInformation store_browser;
        IDisplayReports display_engine;

        public BrowseTheStore(IRetrieveStoreInformation store_browser, IDisplayReports display_engine)
        {
            this.store_browser = store_browser;
            this.display_engine = display_engine;
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(store_browser.get_items_for<InputModel, OutputModel>(request.map_a<InputModel>()));
        }
    }
}