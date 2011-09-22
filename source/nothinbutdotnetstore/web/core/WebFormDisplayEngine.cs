namespace nothinbutdotnetstore.web.core
{
    public class WebFormDisplayEngine : IDisplayReports
    {
        IFindViewForModel view_registry;
        GetTheCurrentlyExecutingContext current_context;

        public WebFormDisplayEngine(IFindViewForModel view_registry, GetTheCurrentlyExecutingContext current_context)
        {
            this.view_registry = view_registry;
            this.current_context = current_context;
        }

        public void display<ReportModel>(ReportModel model)
        {
            view_registry.get_view_for(model).ProcessRequest(current_context());
        }
    }
}