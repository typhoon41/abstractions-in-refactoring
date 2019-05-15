using Version = TV___Step_4.Models.Data.Version;

namespace TV___Step_4.Interfaces
{
    public interface ISoftware
    {
        Version Version { get; }
        void Upgrade();
    }
}
