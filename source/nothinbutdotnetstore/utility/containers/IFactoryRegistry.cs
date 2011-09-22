namespace nothinbutdotnetstore.utility.containers
{
    public interface IFactoryRegistry
    {
        ICreateObjects factory_for<Dependency>(); 
    }
}