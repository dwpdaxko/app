using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheMainDepartments))]
    public class ViewTheMainDepartmentsSpecs
    {
        public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                            ViewTheMainDepartments>
        {
        }

        public class when_run : concern
        {
            //Arrange
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
                application_feature_that_can_process = depends.on<IApplicationFeature<Department>>();
            };

            //Act
            Because b = () =>
                sut.process(request);

            //Assert
            It should_get_a_list_of_store_departments = () =>
                                                                application_feature_that_can_process.received(
                                                                    x => x.get_items());
                

            static IContainRequestInformation request;
            static IApplicationFeature<Department> application_feature_that_can_process;
        }
    }
}