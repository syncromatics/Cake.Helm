using Cake.Helm.List;
using NUnit.Framework;

namespace Cake.Helm.Tests.List
{
    [TestFixture]
    public class HelmListTest
    {
        [Test]
        public void Test()
        {
            var fixture = new HelmListFixture()
            {
                Settings = new HelmListSettings()
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("list"));
        }
    }
}
