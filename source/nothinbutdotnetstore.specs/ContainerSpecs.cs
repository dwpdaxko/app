using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes<IFetchDependencies, Container>
        {
            
        }

        public class when_fetching_a_dependency_from_the_container : concern
        {
            Establish context = () =>
                {
                    find_type_factories = depends.on<IFindTypeFactories>();
                };

            Because b = () => sut.a<FakeType>();

            It should_get_the_type_factory_based_on_the_specified_dependency =
                () => find_type_factories.received(x => x.factory_for<FakeType>());

            static IFindTypeFactories find_type_factories;
        }
    }

    internal class FakeType
    {
    }
}