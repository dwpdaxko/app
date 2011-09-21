using System.Web;
using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public interface IDisplayAReport<ReportModel> : IHttpHandler
    {
        ReportModel model { get; set; }
    }

    public class ReportFor<ReportModel> : Page,IDisplayAReport<ReportModel>
    {
        public ReportModel model { get; set; }
    }
}