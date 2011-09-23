using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsOfADepartmentRequestMapper : IMapAn<ViewTheDepartmentsOfADepartmentRequest>
    {
        public ViewTheDepartmentsOfADepartmentRequest map_from(NameValueCollection item)
        {
            return new ViewTheDepartmentsOfADepartmentRequest
            {
                department_id = long.Parse(item[PayloadTokens.view_departments_in_department_request.department_id]),
                introduced_into_store_on = DateTime.Parse(item[PayloadTokens.view_departments_in_department_request.introduced_into_store_on]),
                number_of_items = int.Parse(item[PayloadTokens.view_departments_in_department_request.number_of_items])
            };
        }
    }
}