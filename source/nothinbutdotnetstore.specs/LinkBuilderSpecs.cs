using System.Collections.Generic;
using System.Linq;
using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof (LinkBuilder))]
    public class LinkBuilderSpecs
    {
        class FakeRequest {}

        public abstract class concern : Observes<IBuildLinks, LinkBuilder>
        {
        }

        public class when_asked_for_the_a_link_for_a_single_request : concern
        {
            Establish context = () =>
            {
                sut_factory.create_using(() => new LinkBuilder(typeof(FakeRequest)));
            };

            It the_link_items_should_contain_only_one_item_with_the_request_type = () =>
                sut.get_link_items().Count().ShouldEqual(1);

            It the_only_link_item_should_contain_the_request_type = () =>
                sut.get_link_items().Cast<RequestTypeLinkItem>().Single().request_type.ShouldEqual(typeof(FakeRequest));
            
            static LinkBuilder result;
        }
		
    }
}
