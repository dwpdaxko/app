namespace nothinbutdotnetstore.web.core
{
	public interface IFindViewForModel
	{
		void get_view_for_model<ReportModelType>(ReportModelType report_model);
	}
}