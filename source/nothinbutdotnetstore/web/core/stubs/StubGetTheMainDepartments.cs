using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubGetTheMainDepartments : IFetchA<IEnumerable<Department>>
    {
        public IEnumerable<Department> run_using(IContainRequestInformation request)
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }
    }
}