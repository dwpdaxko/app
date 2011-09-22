using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{

    public class QueryFor<ReportModel> : IOrchestrateAnApplicationFeature
    {
        IFetchA<ReportModel> query;
        IDisplayReports display_engine;

        public QueryFor(IFetchA<ReportModel> query, IDisplayReports display_engine)
        {
            this.query = query;
            this.display_engine = display_engine;
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(query.run_using(request));
        }
    }
}