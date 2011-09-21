using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewRegistrySpecs 
    {
        public abstract class concern : Observes<IFindViewForModel, ViewRegistry>
        {
        }

        public class when_asked_to_get_a_view_for_model : concern
        {
            Because b = () =>
                {
                    view = sut.get_view_for(new FakeViewModel());
                };

            It should_return_a_view_which_matches_the_model = 
                () => view.ShouldBeOfType<FakeView>();

            static IDisplayAReport<FakeViewModel> view;
        }
    }


    public class FakeView : IDisplayAReport<FakeViewModel>
    {
        public FakeViewModel model
        {
            get { throw new System.NotImplementedException(); }
        }

        public void render()
        {
            throw new System.NotImplementedException();
        }
    }

    public class FakeViewModel
    {
    }
}