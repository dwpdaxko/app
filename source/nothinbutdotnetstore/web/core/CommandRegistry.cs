using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindCommands
    {
        IEnumerable<IProcessOneRequest> all_commands;
        IProcessOneRequest special_case;

        public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands,IProcessOneRequest special_case)
        {
            this.all_commands = all_commands;
            this.special_case = special_case;
        }

        public IProcessOneRequest get_the_command_that_can_process(IContainRequestInformation request)
        {
            return all_commands.First(x => x.can_process(request));
        }
    }
}