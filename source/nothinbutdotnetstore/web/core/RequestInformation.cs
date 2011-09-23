using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.web.core
{
    public class RequestInformation : IContainRequestInformation
    {
        public IFindMappers mapper_registry;
        public NameValueCollection payload;

        public RequestInformation(IFindMappers mapper_registry, NameValueCollection payload)
        {
            this.mapper_registry = mapper_registry;
            this.payload = payload;
        }

        public InputModel map_a<InputModel>()
        {
            return mapper_registry
                .get_mapper_that_can_map<NameValueCollection, InputModel>()
                .map_from(payload);
        }

        public bool was_made_for<InputModel>()
        {
            return payload[UrlTokens.request_type].Equals(typeof(InputModel).Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}