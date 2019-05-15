namespace TV___Step_4.Interfaces
{
    public interface IChannelSwitcher
    {
        void TrySwitching(ushort channelNumber);
        void Next();
        void Previous();
    }
}
