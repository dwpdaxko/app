using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    public class TokenStoreSpecs
    {
        public class concern : Observes<IManageTokens, TokenStore>
        {
        }

        public class when_a_token_has_been_added : concern
        {
            Establish context = () =>
                                {
                                    token = fake.an<Token>();
                                };

            Because b = () =>
                        {
                            sut.store_token_for("foo", 2);
                        };

            It should_return_the_token_during_enumeration = () =>
                                                            {
                                                                sut.Where(token => token.key == "foo" && token.value == "2").Count().ShouldEqual(1);

                                                            };

            static Token token;
        }


    }
}