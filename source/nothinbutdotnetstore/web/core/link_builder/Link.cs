using System;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class Link
    {
        public static LinkBuilderFactory builder_factory = request_type =>
        {
            throw new NotImplementedException("Needs to be configured");
        };

        public static IBuildLinks to_run<T>()
        {
            return builder_factory(typeof(T));
        }
    }
}