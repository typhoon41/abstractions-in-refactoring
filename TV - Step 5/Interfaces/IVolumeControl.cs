using TV___Step_5.Models.Volume;

namespace TV___Step_5.Interfaces
{
    public interface IVolumeControl
    {
        void Increase();
        void Decrease();
        void Reset();
        void Restore(Volume volume);
        void Mute();
        void Unmute();
    }
}
