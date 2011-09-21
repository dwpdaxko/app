using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
	public class DisplayEngineSpecs
	{
		public class concern: Observes<IDisplayReports, WebFormDisplayEngine> {}

		public class when_displaying_a_report_model : concern
		{
			Establish c = () =>
			{
				report_model = new ReportModelForTest();
				view_registry = depends.on<IFindViewForModel>();
			    view = fake.an<IDisplayAReport<ReportModelForTest>>();
			    current_context = ObjectFactory.web.create_http_context();

			    depends.on<GetTheCurrentlyExecutingContext>(() => current_context);
			    view_registry.setup(x => x.get_view_for(report_model)).Return(view);
			};

			Because b = () =>
				sut.display(report_model);


		    It should_tell_the_view_to_render_using_the_currently_executing_http_context = () =>
		        view.received(x => x.ProcessRequest(current_context));
		        

			static ReportModelForTest report_model;
			static IFindViewForModel view_registry;
		    static IDisplayAReport<ReportModelForTest> view;
		    static HttpContext current_context;
		}

		public class ReportModelForTest {}
	}
}