using System;

namespace TV___Step_1.Models
{
    public class Channel
    {
        private const int LowerLimit = 0;
        private const int UpperLimit = 500;

        private int Current { get; }

        public Channel(int given)
        {
            Current = given <= UpperLimit && given >= LowerLimit ? given : throw new ArgumentOutOfRangeException(nameof(given));
        }

        public Channel Next()
        {
            return Current == UpperLimit ? new Channel(LowerLimit) : new Channel(Current + 1);
        }

        public Channel Previous()
        {
            return Current == LowerLimit ? new Channel(UpperLimit) : new Channel(Current - 1);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Channel channel))
            {
                return false;
            }

            return channel.Current == Current;
        }

        public override int GetHashCode()
        {
            return Current.GetHashCode();
        }
    }
}
