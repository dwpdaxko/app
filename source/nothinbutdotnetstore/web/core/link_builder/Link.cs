namespace nothinbutdotnetstore.web.core.link_builder
{
    public class Link
    {
        public static LinkBuilderFactory builder_factory = request_type =>
        {
            var link_builder = new LinkBuilder(new UrlFromTokensBuilder());
            link_builder.set_request_type(request_type);
            return link_builder;
        };

        public static IBuildLinks to_run<T>()
        {
            return builder_factory(typeof(T));
        }
    }
}