using Cake.Helm.Package;
using NUnit.Framework;

namespace Cake.Helm.Tests.Package
{
    [TestFixture]
    public class HelmPackageTest
    {
        [Test]
        public void ShouldPackageWithDefaultSettings()
        {
            var fixture = new HelmPackageFixture
            {
                Path = "./test_charts",
                Settings = new HelmPackageSettings()
            };

            var actual = fixture.Run();

            Assert.That(actual.Args, Is.EqualTo("package ./test_charts"));
        }

        [Test]
        public void ShouldPackageWithAllSettings()
        {
            var fixture = new HelmPackageFixture
            {
                Path = "./test_charts",
                Settings = new HelmPackageSettings
                {
                    Debug = true,
                    Home = "./home",
                    Host = "host",
                    KubeContext = "kube_context",
                    TillerNamespace = "tiller_namespace",

                    AppVersion = "app_version",
                    DependencyUpdate = true,
                    Destination = "destination",
                    Key = "key",
                    Keyring = "keyring",
                    Save = true,
                    Sign = true,
                    Version = "version",
                }
            };

            var actual = fixture.Run();
            Assert.That(actual.Args, Is.EqualTo(@"--debug --home ""./home"" --host ""host"" --kube-context ""kube_context"" --tiller-namespace ""tiller_namespace"" package --app-version ""app_version"" --dependency-update --destination ""destination"" --key ""key"" --keyring ""keyring"" --save --sign --version ""version"" ./test_charts"));
        }
    }
}