using System;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class LinkBuilderFactory : ICreateLinkBuilders
    {
        readonly IProcessAToken visitor;

        public LinkBuilderFactory(IProcessAToken visitor)
        {
            this.visitor = visitor;
        }

        public IBuildLinks build_link(Type request_type)
        {
            return new LinkBuilder(new TokenStore(), request_type, visitor);
        }
    }
}