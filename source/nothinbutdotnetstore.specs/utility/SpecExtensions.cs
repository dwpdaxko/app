using developwithpassion.specifications.core;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs.utility
{
    public static class SpecExtensions
    {
        public static void prepare_container_resolved<Dependency>(this IConfigureSetupPairs spec, ICreateFakes fakes,
                                                                  Dependency dependency)
        {
            var current_resolver = Depends.container_resolver;

            spec.add_setup_teardown_pair(() =>
            {
                var container = fakes.an<IFetchDependencies>();
                container.setup(x => x.a<Dependency>()).Return(dependency);

                ContainerResolver resolver = () => container;
                Depends.container_resolver = resolver;
            }, () =>
            {
                Depends.container_resolver = current_resolver;
            });
        }
    }
}