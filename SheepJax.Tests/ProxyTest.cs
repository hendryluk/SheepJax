using System.Web.Mvc;
using NUnit.Framework;
using System.Linq;
using FluentAssertions;

namespace SheepJax.Tests
{
    [TestFixture]
    public class ProxyTest
    {
        [Test]
        public void ProxyTypeShouldBeCached()
        {
            var proxy1Called = false;
            var proxy2Called = false;

            var proxy1 = SheepJaxProxyGenerator.Instance.Create<ITestCommand>(x=> { proxy1Called = true; });
            var proxy2 = SheepJaxProxyGenerator.Instance.Create<ITestCommand>(x => { proxy2Called = true; });

            proxy1.Foo();
            proxy2.Foo();

            proxy1.GetType().Should().Be(proxy2.GetType());
            
            proxy1Called.Should().BeTrue();
            proxy2Called.Should().BeTrue();
        }

        public interface ITestCommand
        {
            void Foo();
        }


        [Test]
        public void CanRecordCommands()
        {
            var jax = SheepJaxed.Dynamic(cmd =>
                                             {
                                                 cmd.CommandOne(1, "one");
                                                 cmd.CommandTwo("Two", 2, null);
                                             });
            jax.Invocations.Should().HaveCount(2);
            jax.Invocations.ElementAt(0).FunctionName.Should().Be("CommandOne");
            jax.Invocations.ElementAt(0).Args.Should().BeEquivalentTo(1, "one");
            jax.Invocations.ElementAt(1).FunctionName.Should().Be("CommandTwo");
            jax.Invocations.ElementAt(1).Args.Should().BeEquivalentTo("Two", 2, null);
        }
    }
}