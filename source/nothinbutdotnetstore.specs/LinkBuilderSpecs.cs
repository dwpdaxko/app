using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(LinkBuilder))]
    public class LinkBuilderSpecs
    {
        class FakeRequest
        {
        }

        public abstract class concern : Observes<IBuildLinks, LinkBuilder>
        {
            Establish c = () =>
            {
                token_store = depends.on<IManageTokens>();
            };

            protected static IManageTokens token_store;
        }

        public class when_created_for_a_single_request : concern
        {
            Establish context = () =>
            {
                depends.on(typeof(FakeRequest));
            };

            It should_store_a_token_that_represents_the_request_type_in_the_token_store = () =>
                token_store.received(x => x.store_token_for(UrlTokens.request_type, typeof(FakeRequest)));
        }

        public class when_evaluated_as_a_string : concern
        {
            Establish context = () =>
            {
                the_string_built_by_the_visitor = "sdfsdf";

                depends.on<IManageTokens>(new FakeTokens());
                depends.on(typeof(FakeRequest));
                depends.on<IProcessAToken>(new FakeVisitor(the_string_built_by_the_visitor));
            };

            Because b = () =>
                result = sut.ToString();

            It should_return_the_result_of_processing_all_the_tokens_with_the_url_visitor = () =>
                result.ShouldEqual(the_string_built_by_the_visitor);

            static string result;
            static string the_string_built_by_the_visitor;
        }

        public class FakeToken:Token
        {
            
        }
        public class FakeVisitor : IProcessAToken
        {
            string the_result;

            public FakeVisitor(string the_result)
            {
                this.the_result = the_result;
            }

            public void process(Token item)
            {
            }

            public string get_result()
            {
                return the_result;
            }
        }
    }

    public class AnotherRequest
    {
    }

    class FakeTokens : List<Token>, IManageTokens
    {
        public void store_token_for(string token_key, object value)
        {
        }
    }
}