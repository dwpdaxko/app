using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class TokenStore : IManageTokens
    {
        public IDictionary<string, Token> items = new Dictionary<string, Token>();
 
        public IEnumerator<Token> GetEnumerator()
        {
            return items.Values.GetEnumerator();
        }

        public void store_token_for(string token_key, object value)
        {
            items[token_key] = new TokenImpl(token_key, value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class TokenImpl : Token
        {
            public TokenImpl(string token_key, object provided_value)
            {
                key = token_key;
                value = provided_value;
            }

            public string key { get; set; }
            public object value { get; set; }
        }
    }
}