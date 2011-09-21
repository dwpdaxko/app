using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface IFetchA<ReportModel>
    {
        ReportModel run_using(IContainRequestInformation request);
    }
}