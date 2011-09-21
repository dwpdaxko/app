using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class ViewRegistrySpecs
    {
        public abstract class concern : Observes<IFindViewForModel, WebFormViewRegistry>
        {
        }

        public class when_asked_to_get_a_view_for_model : concern
        {
            Establish c = () =>
            {
                model = fake.an<FakeViewModel>();
                view = fake.an<IDisplayAReport<FakeViewModel>>();
                path_from_registry = "blasfsf.aspx";
                path_registry = depends.on<IFindPathsToViews>();

                path_registry.setup(x => x.get_path_to_view_that_can_display<FakeViewModel>())
                    .Return(path_from_registry);

                depends.on<WebFormFactory>((path_to_view,page_type) =>
                {
                    path_to_view.ShouldEqual(path_from_registry);
                    page_type.ShouldEqual(typeof(IDisplayAReport<FakeViewModel>));

                    return view;
                });
            };

            Because b = () =>
                result = sut.get_view_for(model);

                
            It should_create_an_instance_of_the_view_that_can_render_the_model = () =>
                result.ShouldEqual(view);

            It should_set_the_model_on_report = () =>
                view.model.ShouldEqual(model);



                
            static IDisplayAReport<FakeViewModel> view;
            static FakeViewModel model;
            static bool view_was_created;
            static IDisplayAReport<FakeViewModel> result;
            static string path_from_registry;
            static IFindPathsToViews path_registry;
        }
    }

    public class FakeViewModel
    {
    }
}