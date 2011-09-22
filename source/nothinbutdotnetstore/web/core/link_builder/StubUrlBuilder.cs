using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class StubUrlBuilder : IBuildUrlsFromTokens
    {
        public string build(IDictionary<string, string> tokens)
        {
            return "blah";
        }
    }
}