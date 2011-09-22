using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public class LinkBuilder : ILinkBuilder, IFinalLinkBuilder
    {
        public IDictionary<string, string> tokens { get; set; }

        public LinkBuilder()
        {
            tokens = new Dictionary<string, string>();
            tokens[get_request_type_key] = "";
        }

        public void set_request_type(Type type)
        {
            this.tokens[get_request_type_key] = type.Name;
        }

        string get_request_type_key
        {
            get { return "request_type"; }
        }

        public string get_request_type_token
        {
            get { return tokens[get_request_type_key]; }
        }

        public void include<T>(T instance, Expression<Func<T, object>> property)
        {
            var unary_expression = (UnaryExpression) property.Body;
            var member_expression = (MemberExpression) unary_expression.Operand;
            var property_info = (PropertyInfo)member_expression.Member;
            var property_name = property_info.Name;

            var value = property_info.GetValue(instance, null);

            tokens[property_name] = value.ToString();
        }

        public IFinalLinkBuilder conditionally<T>(bool condition)
        {
            if (condition)
                set_request_type(typeof(T));

            return this;
        }
    }

}