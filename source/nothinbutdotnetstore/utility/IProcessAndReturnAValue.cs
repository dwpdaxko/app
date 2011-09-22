namespace nothinbutdotnetstore.utility
{
    public interface IProcessAndReturnAValue<ItemToProcess, TypeToReturn> : IProcessAn<ItemToProcess>
    {
        TypeToReturn get_result();
    }
}