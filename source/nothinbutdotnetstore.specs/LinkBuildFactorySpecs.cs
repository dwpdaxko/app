using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    public class LinkBuildFactorySpecs 
    {
         public abstract class concern : Observes<ICreateLinkBuilders, LinkBuilderFactory>
         {
             
         }

        public class when_asking_the_link_builder_factory_for_a_link_builder : concern
        {
            Establish context = () =>
                {
                    the_visitor = depends.@on<IProcessAToken>();
                };
            
            Because b = () => result = sut.build_link(typeof(FakeType));

            It should_retur_an_instance_of_the_link_builder =
                () =>
                    {
                        var builder = result.ShouldBeAn<LinkBuilder>();
                        builder.tokens.Count().ShouldEqual(1);
                        builder.visitor.ShouldEqual(the_visitor);
                    };

            static IBuildLinks the_link_builder;
            static IBuildLinks result;
            static IProcessAToken the_visitor;
        }
    }
}