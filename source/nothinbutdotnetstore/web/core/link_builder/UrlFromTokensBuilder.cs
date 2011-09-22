using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class UrlFromTokensBuilder : IBuildUrlsFromTokens
    {
        public string build(IDictionary<string, string> tokens)
        {
            var view = tokens["request_type"];

            var query_string = build_query_string(tokens);

            return string.Format("{0}{1}",view,query_string);
        }

        static string build_query_string(IDictionary<string, string> tokens)
        {
            var return_string = "";
            var has_question_mark = false;

            foreach (var token in tokens.Where(x => x.Key != "request_type"))
            {
                if (!has_question_mark)
                {
                    return_string += string.Format("?{0}={1}", token.Key, token.Value);
                    has_question_mark = true;
                }
                else
                {
                    return_string += string.Format("&{0}={1}", token.Key,token.Value);
                }
            }

            return return_string;
        }
    }
}