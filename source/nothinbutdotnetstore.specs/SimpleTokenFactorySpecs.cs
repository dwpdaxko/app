using System.Collections.Specialized;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;

[Subject(typeof(SimpleTokenFactory))]
public class SimpleTokenFactorySpecs
{
    public abstract class concern : Observes<ICreateSimpleTokens, SimpleTokenFactory>
    {
    }

    public class when_creating_a_simple_token : concern
    {
        Establish c = () =>
        {
            the_number = 100;
            collection = new NameValueCollection() {{"something", "100"}};
            mapper = fake.an<IMapDetails<NameValueCollection, int>>();
            mapper_registry = depends.on<IFindMappers>();
            mapper_registry.setup(x => x.get_mapper_that_can_map<string, int>()).Return(mapper);
            mapper.setup(x => x.map_from(collection)).Return(the_number);
        };

        Because b = () =>
            token = sut.named<int>("something");

        It should_create_the_token_using_the_mapper_registry = () =>
            token.map_from(collection).ShouldEqual(the_number);

        static SimpleToken<int> token;
        static IFindMappers mapper_registry;
        static IMapDetails<NameValueCollection, int> mapper;
        static int the_number;
        static NameValueCollection collection;
    }
}