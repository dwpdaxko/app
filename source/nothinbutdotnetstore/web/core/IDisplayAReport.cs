namespace nothinbutdotnetstore.web.core
{
    public interface IDisplayAReport<ReportModel>
    {
        ReportModel model { get; }
        void render();
    }
}