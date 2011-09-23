using System;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public interface IBuildLinks
    {
        IBuildLinks conditionally<RequestType>(bool condition);
        IBuildLinks include<Instance, Property>(Instance instance, Expression<Func<Instance, Property>> propertyExpression);
    }

    public interface ILinkItem
    {
    }
}