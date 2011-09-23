using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubGetTheDepartmentsInADepartment : IFetchA<IEnumerable<Department>>
    {
        public IEnumerable<Department> run_using(IContainRequestInformation request)
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Sub Department 0"),has_products = x %2 ==0});
        }
    }
}