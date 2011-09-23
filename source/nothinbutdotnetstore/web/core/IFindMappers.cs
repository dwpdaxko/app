namespace nothinbutdotnetstore.web.core
{
    public interface IFindMappers
    {
        IMapDetails<Input, Output> get_mapper_that_can_map<Input, Output>();
    }

    public interface IMapDetails<Input, Output>
    {
        Output map_from(Input item);
    }
}