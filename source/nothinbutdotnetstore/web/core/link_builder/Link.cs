using System;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class Link
    {
        public static LinkBuilderFactory builder_factory = delegate
        {
            throw new NotImplementedException("This needs to be configured at startup");
        };

        public static IBuildLinks to_run<T>()
        {
            return builder_factory(typeof(T));
        }
    }
}