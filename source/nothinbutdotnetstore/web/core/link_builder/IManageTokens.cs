using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public interface IManageTokens : IEnumerable<Token>
    {
        void store_token_for(string token_key, object value);
    }
}