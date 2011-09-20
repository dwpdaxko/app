using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindCommands
    {
        private IEnumerable<IProcessOneRequest> processors;
        public CommandRegistry(IEnumerable<IProcessOneRequest> processors)
        {
            this.processors = processors;
        }

        public IProcessOneRequest get_the_command_that_can_process(IContainRequestInformation request)
        {
            foreach(IProcessOneRequest processor in processors)
            {
                if(processor.can_process(request))
                {
                    return processor;
                }
            }
            return new DoNotProcessRequest();
        }
    }
}