using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class SimpleTypeKeySpecs
    {
        public abstract class concern : Observes<IRepresentAType, SimpleTypeKey>
        {

        }

        public class when_seeing_a_key_represents_a_type : concern
        {

            Establish context = () =>
                {
                    depends.on(typeof(FakeType));
                };

            Because b = () => result = sut.represents(typeof(FakeType));

            It should_use_the_type_it_was_created_with_to_test_if_it_represents_the_type =
                () => result.ShouldBeTrue();

            static bool result;    
        }
    }
}