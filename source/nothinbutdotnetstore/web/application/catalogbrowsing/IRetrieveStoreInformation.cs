using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface IRetrieveStoreInformation
    {
        IEnumerable<Department> get_the_main_departments_in_the_store();
        IEnumerable<Department> get_departments_using(ViewTheDepartmentsOfADepartmentInput input_model);
        IEnumerable<Product> get_products_for(ViewTheProductsInADepartmentInputModel department);
    }
}