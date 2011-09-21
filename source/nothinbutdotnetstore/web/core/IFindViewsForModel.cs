namespace nothinbutdotnetstore.web.core
{
	public interface IFindViewForModel
	{
		IDisplayAReport get_view_for<ReportModel>(ReportModel report_model);
	}
}