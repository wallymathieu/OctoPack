namespace OctoPack.Tasks.Util
{
    public class Package
    {
        public readonly string TargetFramework;
        public readonly string Id;
        public readonly string Version;

        public Package(string id, string version, string targetFramework)
        {
            this.Id = id;
            this.Version = version;
            this.TargetFramework = targetFramework;
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
                    && TargetFramework.Equals(other.TargetFramework);
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{{id:{0}, version:{1}, framework:{2}}}", Id, Version, TargetFramework);
        }
    }
}