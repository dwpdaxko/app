 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(AutomaticDependencyFactory))]  
    public class AutomaticDependencyFactorySpecs
    {
        public abstract class concern : Observes<ICreateADependency,
                                            AutomaticDependencyFactory>
        {
        
        }

   
        public class when_creating_a_type_that_has_dependencies : concern
        {
            Establish c = () =>
            {
                first = fake.an<First>();
                second = fake.an<Second>();
                third = fake.an<Third>();

                container = depends.on<IFetchDependencies>();
                ctor_selection_strategy = depends.on<IPickTheConstructorToCreateAType>();
                depends.on(typeof(ATypeWithDependencies));


                ctor_selection_strategy.setup(x => x.pick_applicable_ctor_on(typeof(ATypeWithDependencies)))
                    .Return(ObjectFactory.expressions.to_target<ATypeWithDependencies>().
                    get_ctor(() => new ATypeWithDependencies(null,null,null)));

                container.setup(x => x.a(typeof(First))).Return(first);
                container.setup(x => x.a(typeof(Second))).Return(second);
                container.setup(x => x.a(typeof(Third))).Return(third);
            };

            Because b = () =>
                result = sut.create();


            It should_return_the_type_with_all_of_its_dependencies_satisfied = () =>
            {
                var item = result.ShouldBeAn<ATypeWithDependencies>();
                item.first.ShouldEqual(first);
                item.second.ShouldEqual(second);
                item.third.ShouldEqual(third);
            };

            static object result;
            static First first;
            static Second second;
            static Third third;
            static IFetchDependencies container;
            static IPickTheConstructorToCreateAType ctor_selection_strategy;
        }
    }

    public class ATypeWithDependencies
    {
        public First first { get; set; }

        public Second second { get; set; }

        public Third third { get; set; }

        public ATypeWithDependencies(First first)
        {
            this.first = first;
        }

        public ATypeWithDependencies(First first, Second second, Third third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }
    }

    public class Third
    {
    }

    public class Second
    {
    }

    public class First
    {
    }
}
