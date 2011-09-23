using System;

namespace nothinbutdotnetstore.utility.containers
{
    public delegate ICreateADependency CreateMissingDependencyFactory(Type type_that_has_no_factory);
}