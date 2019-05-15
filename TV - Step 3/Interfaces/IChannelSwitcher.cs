namespace TV___Step_3.Interfaces
{
    public interface IChannelSwitcher
    {
        void TrySwitching(ushort channelNumber);
        void Next();
        void Previous();
    }
}
