namespace nothinbutdotnetstore.web.core
{
	public interface IFindViewForModel
	{
		IDisplayAReport<ReportModel> get_view_for<ReportModel>(ReportModel report_model);
	}
}