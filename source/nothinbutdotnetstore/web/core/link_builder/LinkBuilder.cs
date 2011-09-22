using System;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class LinkBuilder : IBuildLinks
    {
        public IManageTokens tokens;
        public IProcessAToken visitor;

        public LinkBuilder(IManageTokens tokens, Type initial_request, IProcessAToken visitor)
        {
            this.tokens = tokens;
            this.visitor = visitor;
            tokens.store_token_for(UrlTokens.request_type, initial_request);
        }

        public override string ToString()
        {
            return tokens.get_result_of_visiting_all_items_with(visitor);
        }

    }
}