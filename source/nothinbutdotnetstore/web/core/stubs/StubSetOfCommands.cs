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
            yield return create_command<IEnumerable<Department>,StubGetTheMainDepartments>();
            yield return create_command<IEnumerable<Department>,StubGetTheDepartmentsInADepartment>();
            yield return create_command<IEnumerable<Product>,StubGetTheProductsInADepartment>();
        }

        IProcessOneRequest create_command<ReportModel,QueryObject>() where QueryObject : IFetchA<ReportModel>
        {
           return new RequestCommand(x => true,
               Depends.on.a<QueryFor<ReportModel,QueryObject>>>()) 
        }
    }
}