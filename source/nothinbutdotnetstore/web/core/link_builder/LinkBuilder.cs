using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.link_builder
{
	public class LinkBuilder : IBuildLinks
	{
		readonly IBuildUrlsFromTokens url_builder;
		public IDictionary<string, string> tokens { get; set; }

		public LinkBuilder() : this(Stub.with<StubUrlBuilder>())
		{
		}

		public LinkBuilder(IBuildUrlsFromTokens url_builder)
		{
			this.url_builder = url_builder;

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

		public IFinalLinkBuilder include<Instance, Property>(Instance instance, Expression<Func<Instance, Property>> property)
		{
			//var unary_expression = (UnaryExpression) property.Body;
			//var member_expression = (MemberExpression) unary_expression.Operand;

			var member_expression = (MemberExpression) property.Body;
			var property_info = (PropertyInfo)member_expression.Member;
			var property_name = property_info.Name;

			var value = (Property)property_info.GetValue(instance, null);

			tokens[property_name] = value.ToString();

			return this;
		}

		public IFinalLinkBuilder conditionally<T>(bool condition)
		{
			if (condition)
				set_request_type(typeof(T));

			return this;
		}

		public override string ToString()
		{
			return url_builder.build(tokens);
		}
	}
}