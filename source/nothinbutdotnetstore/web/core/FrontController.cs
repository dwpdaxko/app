namespace nothinbutdotnetstore.web.core
{
    public class FrontController :IProcessRequests
    {
    	private readonly IFindCommands _commandRegistry;

    	public FrontController(IFindCommands commandRegistry)
    	{
    		_commandRegistry = commandRegistry;
    	}

    	public void process(IContainRequestInformation request)
    	{
    		var command = _commandRegistry.get_the_command_that_can_process(request);
			command.process(request);
    	}
    }
}