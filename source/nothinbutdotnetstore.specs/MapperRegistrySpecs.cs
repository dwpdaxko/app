 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.utility.containers;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(MapperRegistry))]  
    public class MapperRegistrySpecs
    {
        public abstract class concern : Observes<IFindMappers,
                                            MapperRegistry>
        {
        
        }

   
        public class when_finding_a_mapper_for_a_mapping_pair : concern
        {

                

            public class and_it_has_the_mapper:when_finding_a_mapper_for_a_mapping_pair
            {
                Establish c = () =>
                {
                    the_mapper_from_the_container = fake.an<IMapDetails<int, int>>();
                    container = depends.on<IFetchDependencies>();


                    container.setup(x => x.a<IMapDetails<int,int>>()).Return(the_mapper_from_the_container);
                };

                Because b = () =>
                    result = sut.get_mapper_that_can_map<int, int>();

                It should_return_the_mapper_resolved_by_the_container = () =>
                    result.ShouldEqual(the_mapper_from_the_container);


                static IMapDetails<int,int> result;
                static IMapDetails<int, int> the_mapper_from_the_container;
                static IFetchDependencies container;
            }
                
        }
    }
}
