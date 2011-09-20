using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    class DoNotProcessRequest : IProcessOneRequest
    {
        public void process(IContainRequestInformation request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(IContainRequestInformation request)
        {
            throw new NotImplementedException();
        }
    }
}
