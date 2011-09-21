namespace nothinbutdotnetstore.web.core
{
    public class LinkBuilder : IBuildLinks
    {
        public LinkBuilder(string resource_name)
        {
            resource = resource_name;
        }

        public string resource
        {
            get; private set;
        }
    }
}