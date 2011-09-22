namespace nothinbutdotnetstore.utility
{
    public interface IProcessAn<ItemToProcess>
    {
        void process(ItemToProcess item);
    }
}