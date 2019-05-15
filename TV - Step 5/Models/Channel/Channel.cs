using System;
using TV___Step_5.Interfaces;

namespace TV___Step_5.Models.Channel
{
    public class Channel : IStateful<Channel>
    {
        private const ushort LowerLimit = 0;
        private const ushort UpperLimit = 500;

        public Channel(ushort given)
        {
            Value = given <= UpperLimit ? given : throw new ArgumentOutOfRangeException(nameof(given));
        }

        public static Channel FromInput(ushort given)
        {
            return given <= UpperLimit ? new Channel(given) : null;
        }

        private ushort Value { get; }

        public Channel Next()
        {
            return Value == UpperLimit ? new Channel(LowerLimit) : new Channel((ushort)(Value + 1));
        }

        public Channel Previous()
        {
            return Value == LowerLimit ? new Channel(UpperLimit) : new Channel((ushort)(Value - 1));
        }

        public Channel Reset()
        {
            const ushort defaultOne = 0;
            return new Channel(defaultOne);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Channel channel))
            {
                return false;
            }

            return channel.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
