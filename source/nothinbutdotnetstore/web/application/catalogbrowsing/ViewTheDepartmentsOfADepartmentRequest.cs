using System;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsOfADepartmentRequest
    {
        public long department_id { get; set; }
        public DateTime introduced_into_store_on { get; set; }
        public int number_of_items { get; set; }
    }
}