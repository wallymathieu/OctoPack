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
                    version: GetAttributeValueOrNull(elem, "version"),
                    targetFramework: GetAttributeValueOrNull(elem, "targetFramework"),
                    developmentDependency: "true".Equals(GetAttributeValueOrNull(elem, "developmentDependency"))));
        }

        private static string GetAttributeValueOrNull(XElement elem, string name)
        {
            var attribute = elem.Attribute(name);
            return attribute != null ? attribute.Value : null;
        }
    }
}
