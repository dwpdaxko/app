using System;
using System.Linq.Expressions;
using System.Reflection;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class LinkBuilder : IBuildLinks
    {
        public IManageTokens tokens;
        public IProcessAToken visitor;


        public LinkBuilder(IManageTokens tokens, Type initial_request, IProcessAToken visitor)
        {
            this.tokens = tokens;
            this.visitor = visitor;
            tokens.store_token_for(UrlTokens.request_type, initial_request);
        }

        public override string ToString()
        {
            return tokens.get_result_of_visiting_all_items_with(visitor);
        }

        public IBuildLinks conditionally<RequestType>(bool condition)
        {
            if (condition)
                tokens.store_token_for(UrlTokens.request_type, typeof(RequestType));

            return this;
        }

        public IBuildLinks include<Instance, Property>(Instance instance, Expression<Func<Instance, Property>> propertyExpression)
        {
            var memberExpression = (MemberExpression) propertyExpression.Body;
            var propertyInfo = (PropertyInfo) memberExpression.Member;
            var propertyName = propertyInfo.Name;

            var value = propertyInfo.GetValue(instance, null);

            tokens.store_token_for(propertyName, value);

            return this;
        }
    }
}