using System;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubMissingCommand : IProcessOneRequest
    {
        public void process(IContainRequestInformation request)
        {
            throw new NotImplementedException("Not working");
        }

        public bool can_process(IContainRequestInformation request)
        {
            return false;
        }
    }
}