using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class Link
    {
        public static IBuildLinks to_run<T>()
        {
            return Depends.on.a<IBuildLinks>();
        }
    }
}