using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs.utility
{
    public class ObjectFactory
    {
        public class expressions
        {
            public static ExpressionUtility<Target> to_target<Target>()
            {
                
            }
        }

        public static class web
        {
            public static HttpContext create_http_context()
            {
                return new HttpContext(create_request(), create_response());
            }

            static HttpRequest create_request()
            {
                return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
            }

            static HttpResponse create_response()
            {
                return new HttpResponse(new StringWriter());
            }
        }
    }

    public class ExpressionUtility<T>
    {
        public ConstructorInfo get_ctor(Expression<Func<T>> factory)
        {
            return factory.Body.downcast_to<NewExpression>().Constructor;
        }
    }
}