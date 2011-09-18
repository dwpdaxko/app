using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace nothinbutdotnetstore.specs
{
    public class MessageGeneratorSpecs
    {
        public abstract class concern : Observes<MessageGenerator>
        {
        }

        [Subject(typeof(MessageGenerator))]
        public class when_displaying_a_message : concern
        {
            Establish c = () =>
            {
                message = "hello world";
                depends.on(message);
            };

            Because b = () =>
                result = sut.display_message();

            It should_display_the_message_it_was_created_with = () =>
                result.ShouldEqual(message);

            static string result;
            static string message;
        }
    }
}