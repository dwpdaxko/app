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
				factory = fake.an<ICreateOneObject>();
                find_type_factories = depends.on<IFindTypeFactories>();

				find_type_factories.setup(f=>f.factory_for<FakeType>()).Return(factory);
            };

            Because b = () => 
                sut.a<FakeType>();

            It should_get_the_type_factory_based_on_the_specified_dependency =
                () => find_type_factories.received(x => x.factory_for<FakeType>());

			It should_invoke_the_factory = () => 
				factory.received(x => x.create<FakeType>());

            static IFindTypeFactories find_type_factories;
        	private static ICreateOneObject factory;
        }
    }

    class FakeType
    {
    }
}