using System;

namespace nothinbutdotnetstore.utility.containers
{
    public interface ICreateADependency
    {
    	object create();
        bool can_create(Type type);
    }
}