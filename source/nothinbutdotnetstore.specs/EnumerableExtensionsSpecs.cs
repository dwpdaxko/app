using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    public class EnumerableExtensionsSpecs
    {
        public class concern:Observes
        {
            
        }

        public class when_visiting_all_items_in_an_enumerable_with_an_action
        {
            Establish c = () =>
            {
                items = Enumerable.Range(1, 100).ToList();
            };

            Because b = () =>
                EnumerableExtensions.visit_all_items_using(items, x => number_of_items_processed++);

            It should_process_each_item_using_the_action = () =>
                number_of_items_processed.ShouldEqual(items.Count);

            static int number_of_items_processed;
            static IList<int> items;
        } 

        public class when_visiting_all_items_in_an_enumerable_with_an_visitor:concern
        {
            Establish c = () =>
            {
                visitor = fake.an<IProcessAn<int>>();
                items = Enumerable.Range(1, 100).ToList();
            };

            Because b = () =>
                EnumerableExtensions.visit_all_items_using(items, visitor); 

            It should_process_each_item_using_the_visitor = () =>
                items.each(x => visitor.received(y => y.process(x)));


            static int number_of_items_processed;
            static IList<int> items;
            static IProcessAn<int> visitor;
        } 

        public class when_getting_the_result_of_processing_all_items_with_a_visitor:concern
        {
            Establish c = () =>
            {
                the_result = 42;
                visitor = fake.an<IProcessAndReturnAValue<int,int>>();
                items = Enumerable.Range(1, 100).ToList();

                visitor.setup(x => x.get_result()).Return(the_result);
            };

            Because b = () =>
                result =EnumerableExtensions.get_result_of_visiting_all_items_with(items, visitor); 

            It should_process_each_item_using_the_visitor = () =>
                items.each(x => visitor.received(y => y.process(x)));

            It should_return_the_result_of_the_visitor = () =>
                result.ShouldEqual(the_result);



            static int number_of_items_processed;
            static IList<int> items;
            static IProcessAndReturnAValue<int,int> visitor;
            static int result;
            static int the_result;
        } 
    }
}