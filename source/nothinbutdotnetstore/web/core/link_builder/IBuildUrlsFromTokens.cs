using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public interface IBuildUrlsFromTokens
    {
        string build(IDictionary<string, string> tokens);
    }
}