﻿using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(UrlFromTokensBuilder))]
    public class UrlFromTokensBuilderSpecs
    {
        public abstract class concern : Observes<IBuildUrlsFromTokens, UrlFromTokensBuilder>
        {
        }

        public class when_asked_to_build_a_url : concern
        {

            public class and_the_tokens_contains_a_request_type
            {
                Establish c = () =>
                          {
                              tokens = new Dictionary<string, string>()
                                           {
                                               {"request_type","blah"}
                                           };
                          };
                
                It should_use_the_request_type_key_as_the_view = () =>
                    url.ShouldEqual("/blah.daxko");

                It should_have_an_extension_of_daxko = () =>
                    url.ShouldEndWith(".daxko");

                It should_contain_the_relative_path_at_the_beginning_of_the_string = () =>
                    url.StartsWith("/").ShouldBeTrue();
            }

            public class and_the_tokens_contains_other_tokens
            {
                
                Establish c = () =>
                          {
                              tokens = new Dictionary<string, string>()
                                           {
                                               {"request_type","blah"},
                                               {"id","1"}
                                           };
                          };

                It should_start_the_first_parameter_with_a_question_mark= () =>
                    url.ShouldEndWith("?id=1");

            }

            public class and_the_tokens_contains_2_parameters
            {
                
                Establish c = () =>
                          {
                              tokens = new Dictionary<string, string>()
                                           {
                                               {"request_type","blah"},
                                               {"id","1"},
                                               {"name","blah1"}
                                           };
                          };

                It should_start_the_first_parameter_with_a_question_mark= () =>
                    url.ShouldEndWith("?id=1&name=blah1");

            }

            Because b = () =>
                url = sut.build(tokens);

            static IDictionary<string, string> tokens;
            static string url;
        }
    }
}
