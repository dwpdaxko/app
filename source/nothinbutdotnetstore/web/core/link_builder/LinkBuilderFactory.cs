using System;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public interface LinkBuilderFactory
    {
        IBuildLinks build_link(Type request_type);
    }
}