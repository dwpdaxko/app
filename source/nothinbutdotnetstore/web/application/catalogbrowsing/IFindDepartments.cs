using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface IFindDepartments
    {
        IEnumerable<Department> get_the_main_departments_in_the_store();
        IEnumerable<Department> get_departments_using(ViewTheDepartmentsOfADepartmentInput input_model);
    }
}