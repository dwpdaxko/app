using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : ICreateRequests
    {
        public IContainRequestInformation create_request_from(HttpContext context)
        {
            return new StubRequest();
        }

        class StubRequest : IContainRequestInformation
        {
        }
    }
}