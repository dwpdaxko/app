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
                create_to_run<IEnumerable<Department>, StubGetTheMainDepartments, ViewTheMainDepartmentsRequest>();

            yield return
                create_to_run
                    <IEnumerable<Department>, StubGetTheDepartmentsInADepartment, ViewTheDepartmentsOfADepartmentRequest
                        >();
            yield return
                create_to_run
                    <IEnumerable<Product>, StubGetTheProductsInADepartment, ViewTheProductsInADepartmentRequest>();
        }

        IProcessOneRequest create_to_run<ReportModel, Query, RequestType>() where Query : IFetchA<ReportModel>
        {
            return new RequestCommand(x => true,
                                      new QueryFor<ReportModel, Query>(
                                          Depends.on.a<Query>(),
                                          Depends.on.a<IDisplayReports>()));
        }
    }
}