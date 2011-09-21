using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class LinkSpec
    {
        public abstract class concern : Observes
        {
            
        }


        public class when_calling_to_run_for_a_request
        {

            Because b = () => result = Link.to_run<FakeRequest>();

            It should_return_a_link_builder_with_the_resource_equal_to_the_name_of_the_request = 
                () => result.resource.ShouldEqual(typeof(FakeRequest).Name);

            static IBuildLinks result;
        }
         
    }

    internal class FakeRequest
    {
    }
}