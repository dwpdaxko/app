using System.Collections.Specialized;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    public class RequestInformationSpecs
    {
        public class concern : Observes<IContainRequestInformation, RequestInformation>
        {
        }

        public class when_mapping_an_input_model_that_needs_only_querystring_data : concern
        {
            Establish c = () =>
            {
                request_data = new NameValueCollection();
                depends.on(request_data);
                mapper_registry = depends.on<IFindMappers>();
                model = new FakeInputModel();

                mapper = fake.an <IMapDetails<NameValueCollection, FakeInputModel>>();
                mapper.setup(x => x.map_from(request_data)).Return(model);

                mapper_registry.setup(x => x.get_mapper_that_can_map<NameValueCollection, FakeInputModel>()).Return(
                    mapper);
            };

            Because b = () =>
                result = sut.map_a<FakeInputModel>();

            It should_return_the_item_mapped_from_the_mapper = () =>
                result.ShouldEqual(model);

            static FakeInputModel result;
            static IMapDetails<NameValueCollection, FakeInputModel> mapper;
            static NameValueCollection request_data;
            static FakeInputModel model;
            static IFindMappers mapper_registry;
        }

        public class when_determining_whether_a_request_was_made_for_a_input_model : concern
        {
            public class and_there_is_a_request_type_token_that_matches_the_name_of_the_input_model
            {
                Establish c = () =>
                {
                    collection = new NameValueCollection() {{UrlTokens.request_type, typeof(FakeInputModel).Name}};
                    depends.on(collection);
                };

                It should_return_true = () =>
                    sut.can_map_a<FakeInputModel>().ShouldBeTrue();

                static NameValueCollection collection;
                static ICreateSimpleTokens token_factory;
                static IFetchDependencies resolver;
            }

            public class and_there_is_not_a_request_type_token_that_matches_the_name_of_the_input_model
            {
                Establish c = () =>
                {
                    collection = new NameValueCollection() { { UrlTokens.request_type, "blah" } };
                    depends.on(collection);
                };

                It should_return_false = () =>
                    sut.can_map_a<FakeInputModel>().ShouldBeFalse();

                static NameValueCollection collection;
                static ICreateSimpleTokens token_factory;
                static IFetchDependencies resolver;
            }
        }

        public class FakeInputModel
        {
        }
    }
}