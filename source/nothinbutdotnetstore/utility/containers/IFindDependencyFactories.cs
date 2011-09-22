using System;

namespace nothinbutdotnetstore.utility.containers
{
    public interface IFindDependencyFactories
    {
        ICreateADependency find_factory_for(Type dependency_type); 
    }
}