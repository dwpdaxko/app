using System;
using System.Collections.Specialized;
using Machine.Specifications;
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
            public class and_all_the_information_is_there : concern
            {
                public class and_it_is_valid : concern
                {
                    Establish context = () =>
                    {
                        name_value_collection = new NameValueCollection();
                        name_value_collection.Add("department_id", "1");
                        name_value_collection.Add("introducted_into_store_on", "1/1/2001");
                        name_value_collection.Add("number_of_items", "2");
                    };

                    Because b = () =>
                        result = sut.map_from(name_value_collection);

                    It should_return_a_request_with_the_correct_information = () =>
                    {
                        result.department_id.ShouldEqual(1);
                        result.introduced_into_store_on.ShouldEqual(DateTime.Parse("1/1/2001"));
                        result.number_of_items.ShouldEqual(2);
                    };

                    static NameValueCollection name_value_collection;
                    static ViewTheDepartmentsOfADepartmentRequest result;
                }
            }
        }
    }
}