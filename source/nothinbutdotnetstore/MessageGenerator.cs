namespace nothinbutdotnetstore
{
    public class MessageGenerator
    {
        string message;

        public MessageGenerator(string message)
        {
            this.message = message;
        }

        public string display_message()
        {
            return message;
        }
    }
}