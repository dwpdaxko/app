using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.application.catalogbrowsing;

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
                new RequestCommand(x => true,
                                   Depends.on.a<QueryFor<IEnumerable<Department>, StubGetTheMainDepartments>>());
            yield return
                new RequestCommand(x => true,
                                   Depends.on.a<QueryFor<IEnumerable<Department>, StubGetTheDepartmentsInADepartment>>())
                ;
            yield return
                new RequestCommand(x => true,
                                   Depends.on.a<QueryFor<IEnumerable<Product>, StubGetTheProductsInADepartment>>());
        }
    }
}