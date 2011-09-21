using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands:IEnumerable<IProcessOneRequest>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneRequest> GetEnumerator()
        {
            yield return new RequestCommand(x => true, new QueryFor<IEnumerable<Department>>(new GetTheMainDepartments()));
            yield return new RequestCommand(x => true, new ViewTheDepartmentsOfADepartment());
            yield return new RequestCommand(x => true, new ViewTheMainDepartments());
        }
        public class GetTheMainDepartments:IFetchA<IEnumerable<Department>>
        {
            public IEnumerable<Department> run_using(IContainRequestInformation request)
            {
                return Stub.with<StubDepartmentRepository>().get_the_main_departments_in_the_store();
            }
        }

        public class GetTheProductsInADepartment:IFetchA<IEnumerable<Product>>
        {
            public IEnumerable<Product> run_using(IContainRequestInformation request)
            {
                return
                    Stub.with<StubDepartmentRepository>().get_products_for(
                        request.map_a<ViewTheProductsInADepartmentInputModel>());
            }
        }
    }
}