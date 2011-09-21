using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
	public class DisplayEngineSpecs
	{
		public class concern: Observes<IDisplayReports, DisplayEngine> {}

		public class when_displaying_a_report_model : concern
		{
			Establish c = () =>
			{
				report_model = new ReportModelForTest();
				view_registry = depends.on<IFindViewForModel>();
			    view = fake.an<IDisplayAReport<ReportModelForTest>>();

				view_registry.setup(x => x.get_view_for(report_model)).Return(view);
			};

			Because b = () =>
				sut.display(report_model);


		    It should_tell_the_view_to_render = () =>
		        view.received(x => x.render());
		        

			static ReportModelForTest report_model;
			static IFindViewForModel view_registry;
		    static IDisplayAReport<ReportModelForTest> view;
		}

		public class ReportModelForTest {}
	}
}