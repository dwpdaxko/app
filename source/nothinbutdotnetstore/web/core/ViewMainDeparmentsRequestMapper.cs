using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDeparmentsRequestMapper : IMapAnInputModelOf<ViewMainDepartmentsRequest>
    {
        public ViewMainDepartmentsRequest map_from(NameValueCollection item)
        {
            return new ViewMainDepartmentsRequest();
        }
    }

    public class ViewMainDepartmentsRequest
    {
    }
}