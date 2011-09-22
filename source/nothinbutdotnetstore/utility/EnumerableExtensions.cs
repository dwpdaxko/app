using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility
{
    public static class EnumerableExtensions
    {
        public static void visit_all_items_using<T>(this IEnumerable<T> items, IProcessAn<T> visitor)
        {
            items.visit_all_items_using(visitor.process);
        }

        public static void visit_all_items_using<T>(this IEnumerable<T> items, Action<T> visitor)
        {
            foreach (var item in items) visitor(item);
        }

        public static ReturnType get_result_of_visiting_all_items_with<ItemToVisit,ReturnType>(this IEnumerable<ItemToVisit> items, IProcessAndReturnAValue<ItemToVisit, ReturnType> visitor)
        {
            items.visit_all_items_using(visitor);
            return visitor.get_result();
        }
    }
}