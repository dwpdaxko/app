using System.Collections.Generic;
using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(LinkBuilder))]
    public class LinkBuilderSpecs
    {
        public abstract class concern : Observes<ILinkBuilder,LinkBuilder>
        {
        }


        public class when_asked_for_a_conditional: concern
        {
            public class that_evaluates_to_true
            {
                Because b = () =>
                    final_builder = sut.conditionally<LinkBuilder>(true);

                It should_return_a_final_link_builder = () =>
                    final_builder.ShouldBeAn<IFinalLinkBuilder>();

                It should_replace_the_request_type_value_with_the_type_of_the_conditional_generic_type = () =>
                    sut.get_request_type_token.ShouldEqual("LinkBuilder");

                static IFinalLinkBuilder final_builder;
            }

            public class when_overriding_the_tostring_method : concern
            {
                Establish context = () =>
                    {
                        url_builder = depends.on<IBuildUrlsFromTokens>();
                    };

                Because b = () =>
                    sut.ToString();

                It should_delegate_building_the_url_to_the_url_builder_with_the_tokens_from_the_link_builder = () =>
                    url_builder.received(x => x.build(sut.tokens));

                static IBuildUrlsFromTokens url_builder;
            }
		
        }

        public abstract class final_concern : Observes<IFinalLinkBuilder,LinkBuilder>
        {
        }

        public class when_asked_to_include_a_property_value : final_concern
        {
            Establish context = () =>
                    {
                        blah = new FakeDepartment() {id = 1};
                    };

            Because b = () =>
                final_builder = sut.include(blah, x => x.id);

            It should_return_a_final_link_builder = () =>
                final_builder.ShouldBeAn<IFinalLinkBuilder>();

            It should_add_the_property_name_and_value_token_of_the_instance = () =>
                sut.tokens["id"].ShouldEqual("1");               

            static FakeDepartment blah;
            static IFinalLinkBuilder final_builder;
        }
    }

    internal class FakeDepartment
    {
        public long id { get; set; }
    }
}
