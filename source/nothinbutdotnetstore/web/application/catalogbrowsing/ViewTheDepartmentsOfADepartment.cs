using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsOfADepartment : IOrchestrateAnApplicationFeature
    {
        readonly IFindDepartments department_repository;
        readonly IDisplayReports display_engine;

        public ViewTheDepartmentsOfADepartment(IFindDepartments department_repository,
            IDisplayReports display_engine)
        {
            this.department_repository = department_repository;
            this.display_engine = display_engine;
        }

        public ViewTheDepartmentsOfADepartment():this(Stub.with<StubDepartmentRepository>(), Stub.with<StubDisplayEngine>())
        {
        }

        public void process(IContainRequestInformation request)
        {
            var child_departments = department_repository.get_departments_using(request.map_a<ViewTheDepartmentsOfADepartmentInput>());
            display_engine.display(child_departments);
        }
    }
}