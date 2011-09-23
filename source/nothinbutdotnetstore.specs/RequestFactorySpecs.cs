 using System.Web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(RequestFactory))]  
    public class RequestFactorySpecs
    {
        public abstract class concern : Observes<ICreateRequests,
                                            RequestFactory>
        {
        
        }

   
        public class when_creating_a_request : concern
        {
            Establish c = () =>
            {
                the_context = ObjectFactory.web.create_http_context();
                mapper_registry = depends.on<IFindMappers>();
            };

            Because b = () =>
                result = sut.create_request_from(the_context);

            It should_create_a_request_with_the_correct_details = () =>
            {
                var item = result.ShouldBeAn<RequestInformation>();
                item.payload.ShouldEqual(the_context.Request.Params);
                item.mapper_registry.ShouldEqual(mapper_registry);
            };

            static IContainRequestInformation result;
            static HttpContext the_context;
            static IFindMappers mapper_registry;
        }
    }
}
