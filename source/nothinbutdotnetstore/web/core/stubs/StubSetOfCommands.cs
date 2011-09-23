using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IProcessOneRequest> GetEnumerator()
        {
            yield return new RequestCommand(x => true, Depends.on.a<QueryFor<IEnumerable<Department>, StubGetTheMainDepartments>>());
            yield return new RequestCommand(x => true, Depends.on.a<QueryFor<IEnumerable<Department>, StubGetTheDepartmentsInADepartment>>());
            yield return new RequestCommand(x => true, Depends.on.a<QueryFor<IEnumerable<Product>, StubGetTheProductsInADepartment>>());

        }

        class StubGetTheMainDepartments : IFetchA<IEnumerable<Department>>
        {
            public IEnumerable<Department> run_using(IContainRequestInformation request)
            {
                return Stub.with<StubDepartmentRepository>().get_the_main_departments_in_the_store();
            }
        }

        class StubGetTheProductsInADepartment : IFetchA<IEnumerable<Product>>
        {
            public IEnumerable<Product> run_using(IContainRequestInformation request)
            {
                return
                    Stub.with<StubDepartmentRepository>().get_products_for(
                        request.map_a<ViewTheProductsInADepartmentInputModel>());
            }
        }
    }

    public class StubGetTheDepartmentsInADepartment:IFetchA<IEnumerable<Department>>
    {
        public IEnumerable<Department> run_using(IContainRequestInformation request)
        {
            return Stub.with<StubDepartmentRepository>().get_departments_using(null);
        }
    }
}