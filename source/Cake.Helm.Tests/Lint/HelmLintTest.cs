using Cake.Helm.Lint;
using NUnit.Framework;

namespace Cake.Helm.Tests.Lint
{
    [TestFixture]
    public class HelmLintTest
    {
        [Test]
        public void ShouldLintWithDefaultSettings()
        {
            var fixture = new HelmLintFixture
            {
                Path = "./test_charts",
                Settings = new HelmLintSettings()
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("lint ./test_charts"));
        }

        [Test]
        public void ShouldLintWithAllSettings()
        {
            var fixture = new HelmLintFixture
            {
                Path = "./test_charts",
                Settings = new HelmLintSettings
                {
                    Debug = true,
                    Home = "./home",
                    Host = "host",
                    KubeContext = "kube_context",
                    TillerNamespace = "tiller_namespace",

                    Namespace = "namespace",
                    Set = new[]
                    {
                        "foo=bar",
                        "bam=baz",
                    },
                    Strict = true,
                    Values = new[]
                    {
                        "values.yaml",
                        "other.yaml",
                    },
                }
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo(@"--debug --home ""./home"" --host ""host"" --kube-context ""kube_context"" --tiller-namespace ""tiller_namespace"" lint --namespace ""namespace"" --set ""foo=bar"" --set ""bam=baz"" --strict --values ""values.yaml"" --values ""other.yaml"" ./test_charts"));
        }
    }
}

namespace Cake.Helm.Tests.Package
{
}
