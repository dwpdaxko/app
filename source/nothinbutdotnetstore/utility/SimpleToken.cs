using System.Collections.Specialized;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.utility
{
    public class SimpleToken<ValueType>
    {
        IFindMappers mapper_registry;
        public string key { get; private set; }


        public SimpleToken(string key,IFindMappers mapper_registry)
        {
            this.mapper_registry = mapper_registry;
            this.key = key;
        }

        public override string ToString()
        {
            return this.key;
        }

        public static implicit operator string(SimpleToken<ValueType> token)
        {
            return token.ToString();
        }

        public ValueType map_from(NameValueCollection payload)
        {
            return mapper_registry.get_mapper_that_can_map<string, ValueType>()
                .map_from(payload[key]);
        }
    }
}