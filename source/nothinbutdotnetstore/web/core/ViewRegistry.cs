namespace nothinbutdotnetstore.web.core
{
    public class ViewRegistry : IFindViewForModel
    {
        public IDisplayAReport<ReportModel> get_view_for<ReportModel>(ReportModel report_model)
        {
            throw new System.NotImplementedException();
        }
    }
}