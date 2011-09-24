using System.Collections.Specialized;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing.stubs
{
    public class StubInputModelMapper<InputModel>:IMapAnInputModelOf<InputModel> where InputModel:new()
    {
        public InputModel map_from(NameValueCollection item)
        {

        }
    }
}