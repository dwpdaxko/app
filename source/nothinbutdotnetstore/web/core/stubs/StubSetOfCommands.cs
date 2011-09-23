using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.aspnet;

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
            yield return
                new RequestCommand(x => x.can_map_a<ViewMainDepartmentsRequest>(),
                                   new QueryFor<IEnumerable<Department>, StubGetTheMainDepartments>(
                                       new StubGetTheMainDepartments(), Depends.on.a<IDisplayReports>()));
            yield return
                new RequestCommand(x => x.can_map_a<ViewTheDepartmentsOfADepartmentRequest>(),
                                   new QueryFor<IEnumerable<Department>, StubGetTheDepartmentsInADepartment>(
                                       new StubGetTheDepartmentsInADepartment(), Depends.on.a<IDisplayReports>()));

            yield return
                new RequestCommand(x => x.can_map_a<ViewTheProductsInADepartmentRequest>(),
                                   new QueryFor<IEnumerable<Product>, StubGetTheProductsInADepartment>(
                                       new StubGetTheProductsInADepartment(), Depends.on.a<IDisplayReports>()));
            
            
        
       
        }
    }
}
