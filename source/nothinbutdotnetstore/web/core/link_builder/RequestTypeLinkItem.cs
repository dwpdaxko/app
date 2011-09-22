using System;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class RequestTypeLinkItem : ILinkItem
    {
        public Type request_type { get; private set; }

        public RequestTypeLinkItem(Type request_type)
        {
            this.request_type = request_type;
        }
    }
}