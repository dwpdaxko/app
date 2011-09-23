using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class TokenStore : IManageTokens
    {
        IDictionary<string, Token> _inner = new Dictionary<string, Token>();
 
        public IEnumerator<Token> GetEnumerator()
        {
            return _inner.Values.GetEnumerator();
        }

        public void store_token_for(string token_key, object value)
        {
            _inner[token_key] = new TokenImpl(token_key, value.ToString());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class TokenImpl : Token
        {
            public TokenImpl(string token_key, string provided_value)
            {
                key = token_key;
                value = provided_value;
            }

            public string key { get; set; }
            public string value { get; set; }
        }
    }
}