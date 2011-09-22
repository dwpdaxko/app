using System;

namespace nothinbutdotnetstore.utility.containers
{
    public class DependencyCreationException:Exception
    {
        public DependencyCreationException(Exception exception, Type dependency_type):base(string.Empty,exception)
        {
            this.type_that_could_not_be_created = dependency_type;
        }

        public Type type_that_could_not_be_created { get; private set; }
    }
}