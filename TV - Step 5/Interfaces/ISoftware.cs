using Version = TV___Step_5.Models.Data.Version;

namespace TV___Step_5.Interfaces
{
    public interface ISoftware
    {
        Version Version { get; }
        void Upgrade();
        void Downgrade();
    }
}
