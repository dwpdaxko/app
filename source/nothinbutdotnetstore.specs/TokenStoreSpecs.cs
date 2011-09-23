using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
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
                tokens = new Dictionary<string,Token>();
                depends.on(tokens);
            };

            Because b = () =>
            {
                sut.store_token_for("foo", 2);
            };

            It should_add_the_token_to_the_underlying_backing_store = () =>
                tokens["foo"].value.ShouldEqual(2);

            static Token token;
            static IDictionary<string, Token> tokens;
        }
    }
}