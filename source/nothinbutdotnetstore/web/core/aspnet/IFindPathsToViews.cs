namespace nothinbutdotnetstore.web.core.aspnet
{
    public interface IFindPathsToViews
    {
        string get_path_to_view_that_can_display<ReportModel>();
    }
}