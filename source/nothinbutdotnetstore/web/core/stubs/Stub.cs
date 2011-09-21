using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class Stub
    {
        public static StubType with<StubType>()
        {
            return (StubType) Activator.CreateInstance(typeof(StubType));
        }
    }
}
