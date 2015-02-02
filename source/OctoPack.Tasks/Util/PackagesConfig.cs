using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OctoPack.Tasks.Util
{
    public class PackagesConfig
    {
        public IEnumerable<Package> GetPackages(string packagesConfig)
        {
            var doc = XDocument.Parse(packagesConfig);
            var packages = doc.Element("packages");
            return packages.Elements("package").Select(elem => 
                new Package(
                    elem.Attribute("id").Value,
                    version: elem.Attribute("version").Value,
                    targetFramework: elem.Attribute("targetFramework").Value));
        }
    }
}
