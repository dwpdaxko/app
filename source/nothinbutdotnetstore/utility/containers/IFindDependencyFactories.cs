using System;

namespace nothinbutdotnetstore.utility.containers
{
    public interface IFindDependencyFactories
    {
        ICreateADependency factory_for(Type dependency_type); 
    }
}