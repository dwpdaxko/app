namespace nothinbutdotnetstore.utility.containers
{
    public class MissingTypeFactory : ICreateADependency
    {
        public object create()
        {
            throw new System.NotImplementedException();
        }
    }
}