using System.Collections.Specialized;
using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
	public class RequestInformationSpecs
	{
		public class concern : Observes<IContainRequestInformation, RequestInformation> {} 

		public class when_mapping_an_input_model_that_needs_only_querystring_data : concern
		{
			Establish c = () =>
			{
				var actual_request = depends.on<HttpRequest>();
				actual_request.setup(x => x.QueryString).Return(new NameValueCollection()
				                                                {
				                                                	{"id", "123"}
				                                                });

			};

			Because b = () =>
				result = sut.map_a<FakeInputModel>();

			private It should_return_an_instance_of_specified_type_populated_with_data_from_request = () =>
			{
				result.id.ShouldEqual(123);
			};

			private static FakeInputModel result;
		}

		public class FakeInputModel
		{
			public int id { get; set; }
		}
	}

}