using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RequestFactory : ICreateRequests
    {
        IFindMappers mapper_registry;

        public RequestFactory(IFindMappers mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public IContainRequestInformation create_request_from(HttpContext context)
        {
            return new RequestInformation(mapper_registry, context.Request.Params);
        }
    }
}