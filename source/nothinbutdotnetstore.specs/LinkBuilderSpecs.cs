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
        class FakeRequest {}
        class AnotherFakeRequest {}

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

        public class when_conditionally_using_a_request_model: concern
        {
            Establish c = () =>
            {
                token_store = depends.on<IManageTokens>();
            };


            public class and_the_condition_is_met:when_conditionally_using_a_request_model
            {

                Because b = () =>
                                sut.conditionally<AnotherFakeRequest>(true);

                It should_use_the_conditional_request = () =>
                      token_store.received(x => x.store_token_for(UrlTokens.request_type, typeof(AnotherFakeRequest)));
            }

            public class and_the_condition_is_not_met : when_conditionally_using_a_request_model
            {
                Because b = () =>
                            sut.conditionally<AnotherFakeRequest>(false);

                It should_use_the_conditional_request = () =>
                            token_store.never_received(x => x.store_token_for(UrlTokens.request_type, typeof (AnotherFakeRequest)));
            }

            static IManageTokens token_store;
        }

        public class when_including_a_parameter : concern
        {
            public class FakeModel
            {
                public int property { get; set; }
            }

            Establish c = () =>
                          {
                              token_store = depends.on<IManageTokens>();
                              parameter_value = 1;
                              model = new FakeModel() {property = parameter_value};
                          };

            Because b = () => 
                sut.include(model, m => m.property);

            It should_include_a_parameter_token = () => 
                token_store.received(x => x.store_token_for("property", parameter_value));

            static IManageTokens token_store;
            static FakeModel model;
            static int parameter_value;
        }

        public class FakeToken:Token
        {
            public string key { get; set; }
            public object value { get; set; }
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