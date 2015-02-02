namespace OctoPack.Tasks.Util
{
    public class Package
    {
        public readonly string TargetFramework;
        public readonly string Id;
        public readonly string Version;
        public readonly bool DevelopmentDependency;
        public Package(string id, string version, string targetFramework, bool developmentDependency)
        {
            this.Id = id;
            this.Version = version;
            this.TargetFramework = targetFramework;
            this.DevelopmentDependency = developmentDependency;
        }
        public override bool Equals(object obj)
        {
            if (null == obj)
            {
                return false;
            }
            if (obj is Package)
            {
                var other = (Package)obj;
                return Id.Equals(other.Id)
                    && Version.Equals(other.Version)
                    && TargetFramework.Equals(other.TargetFramework)
                    && DevelopmentDependency.Equals(other.DevelopmentDependency);
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{{id:{0}, version:{1}, framework:{2}, developmentDependency:{3}}}", Id, Version, TargetFramework, DevelopmentDependency);
        }
    }
}