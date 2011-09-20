namespace nothinbutdotnetstore.web.core
{
    public class RequestCommand : IProcessOneRequest
    {
        RequestMatch request_match;

        public RequestCommand(RequestMatch request_match)
        {
            this.request_match = request_match;
        }

        public void process(IContainRequestInformation request)
        {
            throw new System.NotImplementedException();
        }

        public bool can_process(IContainRequestInformation request)
        {
            return request_match(request);
        }
    }
}