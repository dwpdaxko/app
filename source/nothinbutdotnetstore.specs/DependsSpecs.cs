using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class DependsSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_providing_access_to_the_underlying_container : concern
        {
            Establish c = () =>
                {
                    the_container_facade = fake.an<IFetchDependencies>();
                    ContainerResolver resolver = () => the_container_facade;
                    spec.change(() => Depends.container_resolver).to(resolver);
                };

            Because b = () =>
                        result = Depends.on;

            It should_return_the_container_facade_resolved_using_the_container_resolver = 
                () => result.ShouldEqual(the_container_facade);

            static IFetchDependencies result;
            static IFetchDependencies the_container_facade;
        }
    }
}