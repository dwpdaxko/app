using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
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
            };

            //Act
            Because b = () =>
                sut.process(request);

            //Assert
            It first_observation = () =>

            static IContainRequestInformation request; 
        }
    }
}