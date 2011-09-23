using System.Text;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class LinkVisitor : IProcessAToken
    {
        string page_name;
        string querystring;

        public void process(Token item)
        {
            if(item.key == UrlTokens.request_type)
            {
                page_name = item.value;
            }
            else
            {
                if(!string.IsNullOrEmpty(querystring))
                {
                    querystring += "&";
                }

                querystring += string.Format("{0}={1}", item.key, item.value);
            }
        }

        public string get_result()
        {
            var sb = new StringBuilder("/");
            sb.Append(page_name);
            sb.Append(".daxko");

            if (!string.IsNullOrEmpty(querystring))
            {
                sb.Append("?");
                sb.Append(querystring);
            }

            return sb.ToString();
        }
    }
}