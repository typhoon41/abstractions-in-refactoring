namespace TV___Step_3.Models.Data
{
    public class Version
    {
        public byte Major { get; }
        public byte Minor { get; }
        public ushort Build { get; }

        public Version(byte major, byte? minor = null, ushort? build = null)
        {
            Major = major;
            Minor = minor ?? 0;
            Build = build ?? 0;
        }

        public static implicit operator string(Version version)
        {
            return $"V{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}
