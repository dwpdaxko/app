using System.Collections.Generic;
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
                sut.include(blah, x => x.id);
            
            It should_add_the_property_name_and_value_token_of_the_instance = () =>
                sut.tokens["id"].ShouldEqual("1");               

            static FakeDepartment blah;
        }
    }

    internal class FakeDepartment
    {
        public long id { get; set; }
    }
}
