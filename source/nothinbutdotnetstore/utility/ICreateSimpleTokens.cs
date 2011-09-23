namespace nothinbutdotnetstore.utility
{
    public interface ICreateSimpleTokens
    {
        SimpleToken<ValueType> named<ValueType>(string key);
    }
}