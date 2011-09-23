using System;

namespace nothinbutdotnetstore.utility.containers.simple
{
    public class SimpleDependencyFactory : ICreateADependency
    {
    	private Func<object> factory_method;

    	public SimpleDependencyFactory(Func<object> factoryMethod)
    	{
    		factory_method = factoryMethod;
    	}

    	public object create()
        {
        	return factory_method();
        }
    }
}