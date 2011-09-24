using System;
using System.Text;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class LinkVisitor : IProcessAToken
    {
        string querystring;
        int number_of_items_visited;

        public void process(Token item)
        {
            if(!string.IsNullOrEmpty(querystring))
            {
                querystring += "&";
            }

            querystring += string.Format("{0}={1}", item.key, get_value_for(item));
            number_of_items_visited ++;
        }

        string get_value_for(Token item)
        {
            return number_of_items_visited == 0 ? ((Type)item.value).Name : item.value.ToString();
        }

        public string get_result()
        {
            var sb = new StringBuilder("/run.daxko?");

            if (!string.IsNullOrEmpty(querystring))
            {
                sb.Append(querystring);
            }

            return sb.ToString();
        }
    }
}