using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class StartupSpecs
    {
        public abstract class concern : Observes
        {

        }

        public class when_startup_has_completed  : concern
        {
            Because b = () =>
                Startup.run();

            It should_be_able_to_access_key_application_components = () =>
            {
                Depends.on.a<IProcessRequests>().ShouldBeAn<FrontController>();
            };
                
        }
    }
}
