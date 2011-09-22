using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class DependencyFactoryRegistrySpecs
    {
        public class concern : Observes<IFindDependencyFactories, DependencyFactoryRegistry>
        {
        }

        public class when_finding_a_factory_for_a_dependency  : concern
        {
            Establish c = () =>
            {
                factories = Enumerable.Range(1, 100).Select(x => fake.an<ICreateADependency>()).ToList();
                factory_that_can_create_the_dependency = fake.an<ICreateADependency>();
                factories.Add(factory_that_can_create_the_dependency);
                depends.on<IEnumerable<ICreateADependency>>(factories);
                factory_that_can_create_the_dependency.setup(x => x.can_create(typeof(FakeDependency))).Return(true);
            };

            Because b = () =>
                factory = sut.find_factory_for(typeof(FakeDependency));

            It should_return_the_factory_that_knows_how_to_create_the_dependency = () =>
                factory.ShouldEqual(factory_that_can_create_the_dependency);

            static List<ICreateADependency> factories;
            static ICreateADependency factory_that_can_create_the_dependency;
            static ICreateADependency factory;
        }

        class FakeDependency
        {
        }
    }
}
