using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface IApplicationFeature<T>
    {
        IEnumerable<T> get_items();
    }
}