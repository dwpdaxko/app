using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewTheDepartmentsInADepartmentRequestMapperSpecs
    {
        public abstract class concern : Observes<IMapAn<ViewTheDepartmentsOfADepartmentRequest>,
                                            ViewTheDepartmentsOfADepartmentRequestMapper>
        {
        }

        public class when_mapping : concern
        {
            public class and_all_the_information_is_there
            {
                public class and_it_is_valid
                {
                }
            }
        }
    }
}