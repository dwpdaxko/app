using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewPathRegistry : IFindPathsToViews
    {
        public string get_path_to_view_that_can_display<ReportModel>()
        {
            if (typeof(ReportModel).Equals(typeof(IEnumerable<Department>))) return create_view_path("DepartmentBrowser");

            return create_view_path("ProductBrowser");
        }

        string create_view_path(string page)
        {
            return string.Format("~/views/{0}.aspx", page);
        }
    }
}