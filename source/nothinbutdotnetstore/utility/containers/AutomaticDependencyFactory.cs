using System;
using System.Linq;

namespace nothinbutdotnetstore.utility.containers
{
    public class AutomaticDependencyFactory : ICreateADependency
    {
        IFetchDependencies container;
        IPickTheConstructorToCreateAType constructor_specification;
        Type type_to_create;

        public AutomaticDependencyFactory(IFetchDependencies container, IPickTheConstructorToCreateAType constructor_specification, Type type_to_create)
        {
            this.container = container;
            this.constructor_specification = constructor_specification;
            this.type_to_create = type_to_create;
        }

        public object create()
        {
            var constructor = constructor_specification.pick_applicable_ctor_on(type_to_create);
            var parameters = constructor.GetParameters().Select(x => container.a(x.ParameterType)).ToArray();
            return constructor.Invoke(parameters);
        }
    }
}