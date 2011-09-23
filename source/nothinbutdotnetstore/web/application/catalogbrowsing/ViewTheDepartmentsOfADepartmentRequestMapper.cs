using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsOfADepartmentRequestMapper : IMapAn<ViewTheDepartmentsOfADepartmentRequest>
    {
        public ViewTheDepartmentsOfADepartmentRequest map_from(NameValueCollection item)
        {
            var token_builder = New.token_builder().target<ViewTheDepartmentsOfADepartmentRequest>(item)
            return new ViewTheDepartmentsOfADepartmentRequest
            {

    department_id = token_builder.item(x => x.department_id),
                introduced_into_store_on =token_builder.item(x => x.intro).
                number_of_items = token_builder.item(x => x.number_of_items)
            };
            };
        }
    }
}