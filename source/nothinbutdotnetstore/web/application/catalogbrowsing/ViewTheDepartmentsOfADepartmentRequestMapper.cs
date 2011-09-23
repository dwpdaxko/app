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
            };
        }
    }
}