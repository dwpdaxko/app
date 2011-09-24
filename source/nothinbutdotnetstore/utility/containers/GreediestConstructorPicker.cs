using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.utility.containers
{
    public class GreediestConstructorPicker : IPickTheConstructorToCreateAType
    {
        public ConstructorInfo pick_applicable_ctor_on(Type type)
        {
            return type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).First();
        }
    }
}