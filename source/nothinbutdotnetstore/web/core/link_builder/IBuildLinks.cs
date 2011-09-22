using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public interface IBuildLinks
    {
        IEnumerable<ILinkItem> get_link_items();
    }

    public interface ILinkItem
    {
    }
}