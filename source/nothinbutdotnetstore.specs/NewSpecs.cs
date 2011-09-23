using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.containers;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class NewSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_providing_access_to_the_token_builder  : concern
        {
            Establish c = () =>
            {
                the_token = new SimpleToken<int>("sdfsd", null);
                token_factory = fake.an<ICreateSimpleTokens>();
                key = "sdfsdf";

                token_factory.setup(x => x.named<int>(key)).Return(the_token);

                //TODO - figure out how to encapsulate as a reusable test utility
                container = fake.an<IFetchDependencies>();
                container.setup(x => x.a<ICreateSimpleTokens>()).Return(token_factory);

                ContainerResolver resolver = () => container;
                spec.change(() => Depends.container_resolver).to(resolver);
            };

            Because b = () =>
                result = New.token<int>(key);

            It should_return_the_token_builder_from_the_token_factory = () =>
                result.ShouldEqual(the_token);


            static SimpleToken<int> result;
            static SimpleToken<int> the_token;
            static IFetchDependencies container;
            static string key;
            static ICreateSimpleTokens token_factory;
        }
    }
}