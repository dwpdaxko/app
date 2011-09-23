using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.utility
{
    public class SimpleTokenFactory : ICreateSimpleTokens
    {
        IFindMappers mapper_registry;

        public SimpleTokenFactory(IFindMappers mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public SimpleToken<ValueType> named<ValueType>(string key)
        {
            return new SimpleToken<ValueType>(key, mapper_registry);
        }
    }
}