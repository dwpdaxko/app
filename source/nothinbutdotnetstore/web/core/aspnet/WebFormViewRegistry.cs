using System.Web.Compilation;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebFormViewRegistry : IFindViewForModel
    {
        WebFormFactory form_factory;
        IFindPathsToViews path_registry;

        public WebFormViewRegistry(WebFormFactory form_factory, IFindPathsToViews path_registry)
        {
            this.form_factory = form_factory;
            this.path_registry = path_registry;
        }

        public WebFormViewRegistry():this(BuildManager.CreateInstanceFromVirtualPath,
            Stub.with<StubViewPathRegistry>())
        {
        }

        public IDisplayAReport<ReportModel> get_view_for<ReportModel>(ReportModel report_model)
        {
            var view = (IDisplayAReport<ReportModel>)form_factory(path_registry.get_path_to_view_that_can_display<ReportModel>(),
                typeof(IDisplayAReport<ReportModel>));
            view.model = report_model;
            return view;
        }
    }
}