using System;

namespace nothinbutdotnetstore.utility.containers
{
    public class SimpleTypeKey : IRepresentAType
    {
        Type my_type;

        public SimpleTypeKey(Type my_type)
        {
            this.my_type = my_type;
        }

        public bool represents(Type type)
        {
            return my_type.Equals(type);
        }
    }
}