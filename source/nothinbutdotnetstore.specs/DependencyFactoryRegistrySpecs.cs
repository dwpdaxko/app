using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class DependencyFactoryRegistrySpecs
    {
        public class concern : Observes<IFindDependencyFactories, DependencyFactoryRegistry>
        {
        }

        public class when_finding_a_factory_for_a_dependency : concern
        {
            public class and_it_has_the_factory : when_finding_a_factory_for_a_dependency
            {
                Establish c = () =>
                {
                    factory_that_can_create_the_dependency = fake.an<ICreateADependency>();
                    key = fake.an<IRepresentAType>();
                    factories = new Dictionary<IRepresentAType, ICreateADependency>();

                    factories.Add(key, factory_that_can_create_the_dependency);

                    depends.on(factories);
                    key.setup(x => x.represents(typeof(FakeDependency))).Return(true);
                };

                Because b = () =>
                    factory = sut.find_factory_for(typeof(FakeDependency));

                It should_return_the_factory_that_knows_how_to_create_the_dependency = () =>
                    factory.ShouldEqual(factory_that_can_create_the_dependency);

                static IDictionary<IRepresentAType, ICreateADependency> factories;
                static ICreateADependency factory_that_can_create_the_dependency;
                static ICreateADependency factory;
                static IRepresentAType key;
            }

            public class and_it_does_not_have_the_factory : when_finding_a_factory_for_a_dependency
            {
                Establish c =
                    () =>
                    {
                        the_missing_type_factory = fake.an<ICreateADependency>();
                        depends.on(the_missing_type_factory);
                        depends.on<IDictionary<IRepresentAType, ICreateADependency>>(
                            new Dictionary<IRepresentAType, ICreateADependency>());
                    };

                Because b = () =>
                {
                    result = sut.find_factory_for(typeof(FakeDependency));
                };

                It should_return_a_missing_type_factory =
                    () => result.ShouldEqual(the_missing_type_factory);

                static ICreateADependency result;
                static ICreateADependency the_missing_type_factory;
            }
        }

        class FakeDependency
        {
        }
    }
}