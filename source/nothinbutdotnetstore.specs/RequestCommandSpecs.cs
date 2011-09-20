 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(RequestCommand))]  
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<IProcessOneRequest,
                                            RequestCommand>
        {
        
        }

   
        public class when_determining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
                depends.on<RequestMatch>(x => x.Equals(request));
            };

            Because b = () =>
                result = sut.can_process(request);


            It should_make_the_decision_by_leveraging_its_request_specification = () =>
                result.ShouldBeTrue();


            static bool result;
            static IContainRequestInformation request;
        }

        public class when_processing_the_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
                application_feature = depends.on<IOrchestrateAnApplicationFeature>();
            };

            Because b = () =>
                sut.process(request);


            It should_trigger_the_specific_application_feature = () =>
                application_feature.received(x => x.process(request));


            static IContainRequestInformation request;
            static IOrchestrateAnApplicationFeature application_feature;
        }
    }
}
