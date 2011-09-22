using System.Web;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.web.core.aspnet
{
    public class WebHandler : IHttpHandler
    {
        IProcessRequests front_controller;
        ICreateRequests request_factory;

        public WebHandler(IProcessRequests front_controller, ICreateRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public WebHandler():this(Depends.on.a<IProcessRequests>(),
            Depends.on.a<ICreateRequests>())
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            this.front_controller.process(this.request_factory.create_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}