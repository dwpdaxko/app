using System;
using System.Linq;

namespace nothinbutdotnetstore.utility.containers
{
    public class AutomaticDependencyFactory : ICreateADependency
    {
        IFetchDependencies container;
        IPickTheConstructorToCreateAType constructor_picker;
        Type type_to_create;

        public AutomaticDependencyFactory(IFetchDependencies container, IPickTheConstructorToCreateAType constructor_picker, Type type_to_create)
        {
            this.container = container;
            this.constructor_picker = constructor_picker;
            this.type_to_create = type_to_create;
        }

        public object create()
        {
            var constructor = constructor_picker.pick_applicable_ctor_on(type_to_create);
            var parameters = constructor.GetParameters().Select(x => container.a(x.ParameterType));
            return constructor.Invoke(parameters.ToArray());
        }
    }
}