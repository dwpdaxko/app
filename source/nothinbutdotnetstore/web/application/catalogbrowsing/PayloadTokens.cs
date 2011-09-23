using System;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class PayloadTokens
    {
        public class routing
        {
            public static readonly SimpleToken<string> request_type = New.token<string>("request_type");
        }

        public class view_departments_in_department_request
        {
            public static readonly SimpleToken<long> department_id = New.token<long>("department_id");
            public static readonly SimpleToken<int> number_of_items = New.token<int>("number_of_items");
            public static readonly SimpleToken<DateTime> introduced_into_store_on = New.token<DateTime>("introduced_into_store_on");
        } 
    }
}