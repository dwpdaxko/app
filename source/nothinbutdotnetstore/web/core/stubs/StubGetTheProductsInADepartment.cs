using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubGetTheProductsInADepartment : IFetchA<IEnumerable<Product>>
    {
        public IEnumerable<Product> run_using(IContainRequestInformation request)
        {
            return
                Enumerable.Range(1, 100).Select(x => new Product {name = x.ToString("Product 0")});
        }
    }
}