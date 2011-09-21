using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheDepartmentsOfADepartment))]
    public class ViewTheDepartmentsOfADepartmentSpecs
    {
        public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                            ViewTheDepartmentsOfADepartment>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                department_id = 1;

                department_repository = depends.on<IFindDepartments>();
                display_engine = depends.on<IDisplayReports>();

                request = fake.an<IContainRequestInformation>();
                request.setup(x => x.get_parameter("department_id"))
                    .Return(department_id);

                child_departments = new List<Department> { new Department() };
                department_repository.setup(x => x.get_departments_by_parent(department_id))
                    .Return(child_departments);
            };

            Because b = () =>
                sut.process(request);

            It show_children_of_parent_department = () =>
                display_engine.received(x => x.display(child_departments));

            static IFindDepartments department_repository;
            static IDisplayReports display_engine;
            static IContainRequestInformation request;
            static IEnumerable<Department> child_departments;
            static int department_id;
        }
    }
}