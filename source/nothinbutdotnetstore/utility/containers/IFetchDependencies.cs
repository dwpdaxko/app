using System;

namespace nothinbutdotnetstore.utility.containers
{
    public interface IFetchDependencies
    {
        Dependency a<Dependency>();
        object a(Type dependency_type);
    }
}