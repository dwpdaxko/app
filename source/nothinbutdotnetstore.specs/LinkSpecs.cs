using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Link))]
    public class LinkSpecs
    {
        public abstract class concern
        {
        }

        public class when_asked_to_run_a_link: concern
        {

            Because b = () =>
                result = Link.to_run<Link>();

            It should_return_the_link_builder = () =>
                result.ShouldBeAn<IBuildLinks>();

            It should_contain_the_generic_type_name_in_the_dictionary = () =>
                result.tokens.Contains(new KeyValuePair<string, string>("request_type", "Link"));

            static IBuildLinks result;
        }
    }
}
