using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubGetTheMainDepartments : IFetchA<IEnumerable<Department>>
    {
        public IEnumerable<Department> run_using(IContainRequestInformation request)
        {
            return Stub.with<StubDepartmentRepository>().get_the_main_departments_in_the_store();
        }
    }
}