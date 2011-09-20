using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(CommandRegistry))]
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<IFindCommands,
                                            CommandRegistry>
        {
        }

        public class when_finding_a_command_to_process_a_request : concern
        {

            public class and_it_has_the_command
            {
                Establish c = () =>
                {
                    all_the_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneRequest>()).ToList();
                    request = fake.an<IContainRequestInformation>();
                    the_command_that_can_process_the_request = fake.an<IProcessOneRequest>();
                    all_the_commands.Add(the_command_that_can_process_the_request);
                    
                    the_command_that_can_process_the_request.setup(x => x.can_process(request))
                        .Return(true);

                    depends.on<IEnumerable<IProcessOneRequest>>(all_the_commands);
                };

                Because b = () =>
                    result = sut.get_the_command_that_can_process(request);

                It should_return_the_command_to_the_caller = () =>
                    result.ShouldEqual(the_command_that_can_process_the_request);

                static IProcessOneRequest the_command_that_can_process_the_request;
                static IList<IProcessOneRequest> all_the_commands;
            }

            public class and_it_does_not_have_the_command
            {
                Establish c = () =>
                {
                    all_the_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneRequest>()).ToList();
                    the_special_case = fake.an<IProcessOneRequest>();
                    request = fake.an<IContainRequestInformation>();
                    depends.on<IEnumerable<IProcessOneRequest>>(all_the_commands);
                    depends.on(the_special_case);
                };

                Because b = () =>
                    result = sut.get_the_command_that_can_process(request);

                It should_return_the_null_object_implementation_to_the_caller = () =>
                    result.ShouldEqual(the_special_case);

                static IList<IProcessOneRequest> all_the_commands;
                static IProcessOneRequest the_special_case;
            }

            static IProcessOneRequest result;
            static IContainRequestInformation request;
        }
    }
}