using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    public class LinkVisitorSpecs
    {
        public class concern : Observes<IProcessAToken, LinkVisitor>
        {
        }

        public class SomeOtherType
        {
        }

        public class when_visiting_the_first_token : concern
        {
            Establish context = () =>
            {
                first_token = new FakeToken {key = UrlTokens.request_type, value = typeof(SomeOtherType)};
            };

            Because b = () =>
            {
                sut.process(first_token);
                result = sut.get_result();
            };

            It should_return_a_correct_url_string = () =>
                result.ShouldEqual("/run.daxko?" + UrlTokens.request_type + "={0}".format_using(typeof(SomeOtherType).Name));

            static Token token;
            static string result;
            static FakeToken first_token;
        }

        public class when_visiting_a_set_of_tokens_with_parameters : concern
        {
            Establish context = () =>
            {
                var tokens = new List<Token>
                {
                    new FakeToken {key = UrlTokens.request_type, value = typeof(SomeOtherType)},
                    new FakeToken {key = "id", value = "foo"},
                    new FakeToken {key = "bar", value = "baz"}
                };

                sut_setup.run(x => tokens.visit_all_items_using(x.process));
            };

            Because b = () =>
            {
                result = sut.get_result();
            };

            It should_return_a_ = () =>
            {
                result.ShouldEqual("/run.daxko?" + UrlTokens.request_type + "={0}&id=foo&bar=baz".format_using(typeof(SomeOtherType).Name));
            };

            static Token token;
            static string result;
        }

        public class FakeToken : Token
        {
            public string key { get; set; }
            public object value { get; set; }
        }
    }
}