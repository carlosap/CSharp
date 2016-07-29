namespace WebApi.Cache.Settings
{
    public class CacheSettings
    {
        public Memory Memory { get; set; } = new Memory();
        public Disk Disk { get; set; } = new Disk();

    }

    public class Memory
    {
        public bool Enable { get; set; }
        public bool EnableTrace { get; set; }

    }
    public class Disk
    {
        public bool Enable { get; set; }
        public bool EnableTrace { get; set; }
        public bool EnableEncryption { get; set; }
        public string DevDirectory { get; set; }
        public string StagingDirectory { get; set; }
        public string Directory { get; set; }
        public int MaxSizeInMb { get; set; }
    }

}

