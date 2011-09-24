using System;
using System.Reflection;

namespace nothinbutdotnetstore.utility.containers
{
    public interface IPickTheConstructorToCreateAType
    {
        ConstructorInfo pick_applicable_ctor_on(Type type);
    }
}