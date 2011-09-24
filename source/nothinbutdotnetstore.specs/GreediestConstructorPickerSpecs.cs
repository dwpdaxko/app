using System;
using System.Reflection;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class GreediestConstructorPickerSpecs
    {
        public abstract class concern : Observes<IPickTheConstructorToCreateAType, GreediestConstructorPicker>
        {
            
        }

        public class when_picking_a_constructor : concern
        {
            Establish c = () =>
            {
                type_to_create = typeof(TheTypeToCreate);
            };

            Because b = () =>
                result = sut.pick_applicable_ctor_on(type_to_create);

            It should_return_the_constructor_with_the_most_parameters = () =>
                result.GetParameters().Length.ShouldEqual(3);

            static Type type_to_create;
            static ConstructorInfo result;

            class TheTypeToCreate
            {
                public TheTypeToCreate(string first)
                {
                }

                public TheTypeToCreate(string first, string second)
                {
                }

                public TheTypeToCreate(string first, string second, string third)
                {
                }
            }
        }
    }
}
