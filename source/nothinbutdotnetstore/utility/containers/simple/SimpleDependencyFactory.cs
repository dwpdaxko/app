using System;

namespace nothinbutdotnetstore.utility.containers.simple
{
    public class SimpleDependencyFactory : ICreateADependency
    {
    	private Func<object> factory_method;

    	public SimpleDependencyFactory(Func<object> factory_method)
    	{
    		this.factory_method = factory_method;
    	}

    	public object create()
        {
        	return factory_method();
        }
    }
}