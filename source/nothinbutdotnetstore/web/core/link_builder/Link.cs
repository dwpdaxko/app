using System;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class Link
    {

        public static IBuildLinks to_run<T>()
        {
            return builder_factory(typeof(T));
        }
    }
}