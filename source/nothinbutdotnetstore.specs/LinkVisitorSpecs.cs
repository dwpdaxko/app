using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    public class LinknVisitorSpecs
    {
        public class concern : Observes<IProcessAToken, LinkVisitor>
        {
        }

        public class when_visiting_a_request_type_token : concern
        {
            Establish context = () =>
                                {
                                    var tokens = new List<Token>
                                                 {
                                                     new FakeToken() {key = UrlTokens.request_type, value = "CommandTypeName"}
                                                 };

                                    sut_setup.run(x => tokens.visit_all_items_using(x.process));
                                };

            Because b = () =>
                        {
                            result = sut.get_result();
                        };

            It should_return_a_ = () =>
                result.ShouldEqual("/run.daxko?" + UrlTokens.request_type + "=CommandTypeName");

            static Token token;
            static string result;
        }

        public class when_visiting_a_set_of_tokens_with_parameters: concern
        {
            Establish context = () =>
            {
                var tokens = new List<Token>
                                                 {
                                                     new FakeToken() {key = UrlTokens.request_type, value = "CommandTypeName"},
                                                     new FakeToken() {key = "id", value = "foo"},
                                                     new FakeToken() {key = "bar", value = "baz"}
                                                 };

                sut_setup.run(x => tokens.visit_all_items_using(x.process));
            };

            Because b = () =>
            {
                result = sut.get_result();
            };

            It should_return_a_ = () =>
            {
                result.ShouldEqual("/run.daxko?" + UrlTokens.request_type + "=CommandTypeName&id=foo&bar=baz");
            };

            static Token token;
            static string result;
        }

        public class FakeToken : Token
        {
            public string key { get; set; }
            public string value { get; set; }
        }
    }
}