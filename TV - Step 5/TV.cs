using TV___Step_5.Interfaces;
using TV___Step_5.Models;
using TV___Step_5.Models.Data;

namespace TV___Step_5
{
    public abstract class TV
    {
        public abstract IChannelSwitcher ChannelSwitcher { get; }
        public abstract IVolumeControl Volume { get; }
        public abstract Size Size { get; }
        public ITimeManager TimeManager { get; } = new TimeManager();

        public virtual void ToFactorySettings()
        {
            ChannelSwitcher.Reset();
            Volume.Reset();
            TimeManager.Reset();
        }
    }
}
