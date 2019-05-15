namespace TV___Step_5.Interfaces
{
    public interface IChannelSwitcher
    {
        void TrySwitchingTo(ushort channelNumber);
        void Next();
        void Reset();
        void Previous();
    }
}
