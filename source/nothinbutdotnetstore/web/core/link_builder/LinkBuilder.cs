using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core.link_builder
{
	public class LinkBuilder : IBuildLinks
	{
        List<ILinkItem> link_items = new List<ILinkItem>();

	    public LinkBuilder(Type type)
	    {
	        throw new NotImplementedException();
	    }

	    public IEnumerable<ILinkItem> get_link_items()
	    {
	        return link_items;
	    }
	}
}