using System.Collections.Generic;
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
            Establish c = () =>
            {
                department_repository = depends.on<IFindDepartments>();
                the_main_departments = new List<Department>{new Department()};
                display_engine = depends.on<IDisplayReports>();

                request = fake.an<IContainRequestInformation>();

                department_repository.setup(x => x.get_the_main_departments_in_the_store())
                    .Return(the_main_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_display_the_main_departments = () =>
                display_engine.received(x => x.display(the_main_departments));

                

            static IContainRequestInformation request;
            static IFindDepartments department_repository;
            static IEnumerable<Department> the_main_departments;
            static IDisplayReports display_engine;
        }
    }
}