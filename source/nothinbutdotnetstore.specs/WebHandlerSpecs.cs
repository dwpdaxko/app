using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core.aspnet;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(WebHandler))]
    public class WebHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            WebHandler>
        {
        }

        public class when_processing_an_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = depends.on<IProcessRequests>();
                request_factory = depends.on<ICreateRequests>();
                a_new_request_created_from_the_incoming_context  = new object();
                the_incoming_context = ObjectFactory.web.create_http_context();

                request_factory.setup(x => x.create_request_from(the_incoming_context))
                    .Return(a_new_request_created_from_the_incoming_context);
            };

            Because b = () =>
                sut.ProcessRequest(the_incoming_context);

            It should_delegate_the_processing_of_a_request_to_the_front_controller = () =>
                front_controller.received(x => x.process(a_new_request_created_from_the_incoming_context));

            static IProcessRequests front_controller;
            static object a_new_request_created_from_the_incoming_context;
            static HttpContext the_incoming_context;
            static ICreateRequests request_factory;
        }
    }
}