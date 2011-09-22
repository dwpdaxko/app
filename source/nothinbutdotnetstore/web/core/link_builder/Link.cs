using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class Link
    {
        public static ILinkBuilder to_run<T>()
        {
            var link_builder = new LinkBuilder();
            link_builder.set_request_type(typeof (T));
            return link_builder;
        }
    }
}