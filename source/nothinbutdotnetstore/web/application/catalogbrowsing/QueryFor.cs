using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class QueryFor<ReportModel, QueryObject> : IOrchestrateAnApplicationFeature
        where QueryObject : IFetchA<ReportModel>
    {
        IDisplayReports display_engine;
        IFetchA<ReportModel> query;

        public QueryFor(QueryObject query, IDisplayReports display_engine)
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