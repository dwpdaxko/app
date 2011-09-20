namespace nothinbutdotnetstore.web.core
{
    public interface IProcessOneRequest : IOrchestrateAnApplicationFeature
    {
        bool can_process(IContainRequestInformation request);
    }
}