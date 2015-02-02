using NUnit.Framework;
using OctoPack.Tasks.Util;
using System.Linq;
namespace OctoPack.Tests.Tasks
{
    [TestFixture]
    public class PackagesDependencies
    {
        private PackagesConfig _sut;

        [SetUp]
        public void SetUp() 
        {
            _sut = new PackagesConfig();
        }

        [Test]
        public void Packages_GetsIdVersionAndFramework_single_package()
        {
            var _packages_config = @"<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""Newtonsoft.Json"" version=""6.0.8"" targetFramework=""net40"" />
</packages>";
            Assert.AreEqual(new Package("Newtonsoft.Json", version: "6.0.8", targetFramework: "net40"), 
                _sut.GetPackages(_packages_config).Single());
        }


        [Test]
        public void Packages_GetsIdVersionAndFramework()
        {
            var _packages_config = @"<?xml version=""1.0"" encoding=""utf-8""?>
<packages>
  <package id=""Nancy"" version=""0.23.2"" targetFramework=""net40"" />
  <package id=""Nancy.Hosting.Self"" version=""0.23.2"" targetFramework=""net40"" />
  <package id=""Nancy.Serialization.JsonNet"" version=""0.23.2"" targetFramework=""net40"" />
  <package id=""Nancy.ViewEngines.Veil"" version=""0.3.0"" targetFramework=""net40"" />
  <package id=""Newtonsoft.Json"" version=""6.0.8"" targetFramework=""net40"" />
</packages>";
            Assert.AreEqual(new[] {
                    new Package("Nancy", version: "0.23.2", targetFramework: "net40"),
                    new Package("Nancy.Hosting.Self", version: "0.23.2", targetFramework: "net40"),
                    new Package("Nancy.Serialization.JsonNet", version: "0.23.2", targetFramework: "net40"),
                    new Package("Nancy.ViewEngines.Veil", version: "0.3.0", targetFramework: "net40"),
                    new Package("Newtonsoft.Json", version: "6.0.8", targetFramework: "net40")
            }, _sut.GetPackages(_packages_config).ToArray());
        }
    }
}
