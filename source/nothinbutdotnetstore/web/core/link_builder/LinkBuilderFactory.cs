using System;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public delegate IBuildLinks LinkBuilderFactory(Type initial_request_type);
}