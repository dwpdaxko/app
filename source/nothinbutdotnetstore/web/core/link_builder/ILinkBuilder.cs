using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core.link_builder
{
    public interface ILinkBuilder
    {
        IDictionary<string, string> tokens { get; set; }
        IFinalLinkBuilder conditionally<T>(bool condition);
        string get_request_type_token { get; }
    }
}