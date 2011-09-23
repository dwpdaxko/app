using System;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public interface ICreateLinkBuilders
    {
        IBuildLinks build_link(Type request_type);
    }
}