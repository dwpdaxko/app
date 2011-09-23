using System;
using System.Data.SqlClient;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.simple;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(SimpleDependencyFactory))]
    public class SimpleDependencyFactorySpecs
    {
        public abstract class concern : Observes<ICreateADependency,
                                            SimpleDependencyFactory>
        {
        }

        public class when_creating_an_instance_of_a_dependency : concern
        {
            Establish c = () =>
            {
                connection = new SqlConnection();
                depends.on <Func<object>>(() => connection);
            };

            Because b = () =>
                result = sut.create();

            It should_return_the_instance_created_using_its_delegate = () =>
                result.ShouldEqual(connection);

            static object result;
            static object connection;
        }
    }
}