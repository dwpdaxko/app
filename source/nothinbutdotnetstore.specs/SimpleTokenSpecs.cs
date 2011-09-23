using System;
using System.Collections.Specialized;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class SimpleTokenSpecs
    {
        public abstract class concern : Observes<SimpleToken<int>>
        {
        }

        public class when_implicitly_converted_to_a_string : concern
        {
            Establish c = () =>
            {
                the_key = "sfsd";
                depends.on(the_key);
            };

            Because b = () =>
                result = sut;

            It should_return_the_key_it_was_created_with = () =>
                result.ShouldEqual(the_key);

            static string result;
            static string the_key;
        }

        public class when_mapping_itself_from_a_name_value_collection : concern
        {
            Establish c = () =>
            {
                raw_value = "sdfsdfsdf";
                the_mapped_value = 2342;
                key = "sdfsdfsdfsdf";
                depends.on(key);

                payload = new NameValueCollection {{key, raw_value}};

                the_mapper = fake.an<IMapDetails<string, int>>();
                mapper_registry = depends.on<IFindMappers>();
                mapper_registry.setup(x => x.get_mapper_that_can_map<string, int>())
                    .Return(the_mapper);

                the_mapper.setup(x => x.map_from(raw_value)).Return(the_mapped_value);
            };

            Because b = () =>
                result = sut.map_from(payload);

            It should_return_the_value_from_the_discrete_mapper = () =>
                result.ShouldEqual(the_mapped_value);

            static int result;
            static int the_mapped_value;
            static NameValueCollection payload;
            static IFindMappers mapper_registry;
            static IMapDetails<string, int> the_mapper;
            static string raw_value;
            static string key;
        }

        public class when_converted_to_a_string : concern
        {
            Establish c = () =>
            {
                the_key = "sfsd";
                depends.on(the_key);
            };

            Because b = () =>
                result = sut.ToString();

            It should_return_the_key_it_was_created_with = () =>
                result.ShouldEqual(the_key);

            static string result;
            static string the_key;
        }
    }
}