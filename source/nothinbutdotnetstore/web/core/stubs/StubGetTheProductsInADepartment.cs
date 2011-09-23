using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubGetTheProductsInADepartment : IFetchA<IEnumerable<Product>>
    {
        public IEnumerable<Product> run_using(IContainRequestInformation request)
        {
            return
                Stub.with<StubDepartmentRepository>().get_products_for(
                    request.map_a<ViewTheProductsInADepartmentInputModel>());
        }
    }
}