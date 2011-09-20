namespace nothinbutdotnetstore.web.core
{
    public class RequestCommand : IProcessOneRequest
    {
        RequestMatch request_match;
        IOrchestrateAnApplicationFeature application_command;

        public RequestCommand(RequestMatch request_match, IOrchestrateAnApplicationFeature application_command)
        {
            this.request_match = request_match;
            this.application_command = application_command;
        }

        public void process(IContainRequestInformation request)
        {
            application_command.process(request);
        }

        public bool can_process(IContainRequestInformation request)
        {
            return request_match(request);
        }
    }
}