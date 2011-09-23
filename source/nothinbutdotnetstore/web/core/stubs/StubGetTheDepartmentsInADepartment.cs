using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubGetTheDepartmentsInADepartment : IFetchA<IEnumerable<Department>>
    {
        public IEnumerable<Department> run_using(IContainRequestInformation request)
        {
            return Stub.with<StubDepartmentRepository>().get_departments_using(null);
        }
    }
}