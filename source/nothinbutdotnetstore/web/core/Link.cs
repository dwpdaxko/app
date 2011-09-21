namespace nothinbutdotnetstore.web.core
{
    public static class Link
    {
         public static IBuildLinks to_run<Request>()
         {
            return new LinkBuilder(typeof(Request).Name);
         }
    }
}