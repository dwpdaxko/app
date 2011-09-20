namespace nothinbutdotnetstore.web.core
{
    public class FrontController :IProcessRequests
    {
    	IFindCommands command_registry;

    	public FrontController(IFindCommands command_registry)
    	{
    		this.command_registry = command_registry;
    	}

    	public void process(IContainRequestInformation request)
    	{
    	    command_registry.get_the_command_that_can_process(request).process(request);
    	}
    }
}