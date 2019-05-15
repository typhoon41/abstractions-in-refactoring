using TV___Step_4.Interfaces;

namespace TV___Step_4.Models.Volume
{
    public class VolumeControl : IVolumeControl
    {
        private Volume _lastKnownVolume;
        public Volume Current { get; private set; }

        public VolumeControl(Volume lastKnownVolume)
        {
            _lastKnownVolume = lastKnownVolume;
            Current = lastKnownVolume;
        }

        public void Increase()
        {
            Current = Current.Increase();
        }

        public void Decrease()
        {
            Current = Current.Decrease();
        }

        public void Mute()
        {
            _lastKnownVolume = Current.Clone();
            Current = new Volume(0);
        }

        public void Unmute()
        {
            Current = _lastKnownVolume.Clone();
        }
    }
}
