namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubMissingCommand:IProcessOneRequest
    {
        public void process(IContainRequestInformation request)
        {
        }

        public bool can_process(IContainRequestInformation request)
        {
            return false;
        }
    }
}