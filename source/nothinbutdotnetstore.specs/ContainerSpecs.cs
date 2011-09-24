using System;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
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
            public class and_there_is_a_factory_that_can_create_the_dependency :
                when_fetching_a_dependency_from_the_container
            {
                public class in_a_generic_context : when_fetching_a_dependency_from_the_container
                {
                    Establish context = () =>
                    {
                        the_dependency = new FakeType();
                        factory = fake.an<ICreateADependency>();
                        find_dependency_factories = depends.on<IFindDependencyFactories>();

                        find_dependency_factories.setup(f => f.find_factory_for(typeof(FakeType))).Return(factory);
                        factory.setup(x => x.create()).Return(the_dependency);
                    };

                    Because b = () =>
                        result = sut.a<FakeType>();

                    It should_return_the_item_created_by_the_factory = () =>
                        result.ShouldEqual(the_dependency);

                    static IFindDependencyFactories find_dependency_factories;
                    static ICreateADependency factory;
                    static FakeType result;
                    static object the_dependency;
                }

                public class in_a_runtime_context : when_fetching_a_dependency_from_the_container
                {
                    Establish context = () =>
                    {
                        the_dependency = new FakeType();
                        factory = fake.an<ICreateADependency>();
                        find_dependency_factories = depends.on<IFindDependencyFactories>();

                        find_dependency_factories.setup(f => f.find_factory_for(typeof(FakeType))).Return(factory);
                        factory.setup(x => x.create()).Return(the_dependency);
                    };

                    Because b = () =>
                        result = sut.a(typeof(FakeType));

                    It should_return_the_item_created_by_the_factory = () =>
                        result.ShouldEqual(the_dependency);

                    static IFindDependencyFactories find_dependency_factories;
                    static ICreateADependency factory;
                    static object result;
                    static object the_dependency;
                }
            }

            public class and_the_dependency_factory_for_the_dependency_throws_an_exception :
                when_fetching_a_dependency_from_the_container
            {
                Establish context = () =>
                {
                    inner_exception = new Exception();
                    factory = fake.an<ICreateADependency>();
                    find_dependency_factories = depends.on<IFindDependencyFactories>();

                    find_dependency_factories.setup(f => f.find_factory_for(typeof(FakeType))).Return(factory);
                    factory.setup(x => x.create()).Throw(inner_exception);
                };

                Because b = () =>
                    spec.catch_exception(() => sut.a<FakeType>());

                It should_throw_dependency_creation_exception_with_the_correct_details = () =>
                {
                    var exception = spec.exception_thrown.ShouldBeAn<DependencyCreationException>();
                    exception.InnerException.ShouldEqual(inner_exception);
                    exception.type_that_could_not_be_created.ShouldEqual(typeof(FakeType));
                };

                static ICreateADependency factory;
                static IFindDependencyFactories find_dependency_factories;
                static Exception inner_exception;
            }
        }
    }

    public class FakeType
    {
    }
}