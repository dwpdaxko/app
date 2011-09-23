using System.Text;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class LinkVisitor : IProcessAToken
    {
        string querystring;

        public void process(Token item)
        {
            if(!string.IsNullOrEmpty(querystring))
            {
                querystring += "&";
            }

            querystring += string.Format("{0}={1}", item.key, item.value);

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