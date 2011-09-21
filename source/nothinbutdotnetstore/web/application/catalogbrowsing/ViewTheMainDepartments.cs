using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheMainDepartments : IOrchestrateAnApplicationFeature
    {
        IFindDepartments department_repository;
        IDisplayReports display_engine;

        public ViewTheMainDepartments(IFindDepartments department_repository, IDisplayReports display_engine)
        {
            this.department_repository = department_repository;
            this.display_engine = display_engine;
        }

        public ViewTheMainDepartments():this(Stub.with<StubDepartmentRepository>(),
            new StubDisplayEngine())
        {
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(department_repository.get_the_main_departments_in_the_store());
        }
    }
}