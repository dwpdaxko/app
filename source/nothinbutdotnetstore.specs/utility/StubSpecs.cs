using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Stub))]
    public class StubSpecs
    {
        public class StubTest
        {
            
        }

        public abstract class concern : Observes
        {
        }

        public class when_asking_for_an_instance_of_a_stub : concern
        {
            Because b = () =>
                result = Stub.with<StubTest>();

            It should_return_an_instance_of_stub = () =>
                result.ShouldBeOfType<StubTest>();

            static StubTest result;
        }
    }
}