using System.Collections.Generic;

namespace nothinbutdotnetstore.specs
{
    internal interface IApplicationFeature<T>
    {
        IEnumerable<T> get_items();
    }
}