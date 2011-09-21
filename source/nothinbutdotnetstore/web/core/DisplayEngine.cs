namespace nothinbutdotnetstore.web.core
{
    public class DisplayEngine : IDisplayReports
    {
        IFindViewForModel view_registry;

        public DisplayEngine(IFindViewForModel view_registry)
        {
            this.view_registry = view_registry;
        }

        public void display<ReportModel>(ReportModel model)
        {
            view_registry.get_view_for(model).render();
        }
    }
}