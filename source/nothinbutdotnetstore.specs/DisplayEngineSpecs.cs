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
			};

			Because b = () =>
				sut.display(report_model);

			It should_select_the_appropriate_view_for_the_report_model = () =>
				view_registry.received(x => x.get_view_for_model(report_model));

			private static ReportModelForTest report_model;
			private static IFindViewForModel view_registry;
		}

		public class ReportModelForTest {}
	}
}