using System.Collections.Specialized;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsOfADepartmentRequestMapper : IMapAn<ViewTheDepartmentsOfADepartmentRequest>
    {
        public ViewTheDepartmentsOfADepartmentRequest map_from(NameValueCollection item)
        {
            return new ViewTheDepartmentsOfADepartmentRequest
            {
                department_id = PayloadTokens.view_departments_in_department_request.department_id.map_from(item),
                introduced_into_store_on =
                    PayloadTokens.view_departments_in_department_request.introduced_into_store_on.map_from(item),
                number_of_items = PayloadTokens.view_departments_in_department_request.number_of_items.map_from(item)
            };
        }

    }
}
