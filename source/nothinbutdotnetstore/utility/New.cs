using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.utility
{
    public class New
    {
        public static SimpleToken<ValueType> token<ValueType>(string key)
        {
            return Depends.on.a<ICreateSimpleTokens>().named<ValueType>(key);
        }
    }
}