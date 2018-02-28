using Cake.Helm.List;
using NUnit.Framework;

namespace Cake.Helm.Tests.List
{
    [TestFixture]
    public class HelmListTest
    {
        [Test]
        public void ShouldListWithDefaultSettings()
        {
            var fixture = new HelmListFixture
            {
                Settings = new HelmListSettings()
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("list"));
        }

        [Test]
        public void ShouldListWithAllSettings()
        {
            var fixture = new HelmListFixture
            {
                Settings = new HelmListSettings
                {
                    Debug = true,
                    Home = "./home",
                    Host = "host",
                    KubeContext = "kube_context",
                    TillerNamespace = "tiller_namespace",

                    All = true,
                    ColWidth = 99,
                    Date = true,
                    Deleted = true,
                    Deleting = true,
                    Deployed = true,
                    Failed = true,
                    Max = 99,
                    Namespace = "namespace",
                    Offset = "offset",
                    Pending = true,
                    Reverse = true,
                    Short = true,
                    Tls = true,
                    TlsCaCert = "tls_ca_cert",
                    TlsCert = "tls_cert",
                    TlsKey = "tls_key",
                    TlsVerify = true,
                }
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo(@"--debug --home ""./home"" --host ""host"" --kube-context ""kube_context"" --tiller-namespace ""tiller_namespace"" list --all --col-width ""99"" --date --deleted --deleting --deployed --failed --max ""99"" --namespace ""namespace"" --offset ""offset"" --pending --reverse --short --tls --tls-ca-cert ""tls_ca_cert"" --tls-cert ""tls_cert"" --tls-key ""tls_key"" --tls-verify"));
        }
    }
}
