using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ICreateRequests
    {
        IContainRequestInformation create_request_from(HttpContext context);
    }
}