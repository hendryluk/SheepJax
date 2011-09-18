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