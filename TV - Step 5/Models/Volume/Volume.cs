using System;
using TV___Step_5.Interfaces;

namespace TV___Step_5.Models.Volume
{
    public struct Volume : IStateful<Volume>
    {
        public const byte MinValue = 0;
        public const byte MaxValue = 100;

        private readonly byte _value;

        public Volume(byte given)
        {
            _value = given <= MaxValue ? given : throw new ArgumentOutOfRangeException(nameof(given));
        }

        public Volume Increase()
        {
            return _value != MaxValue ? new Volume((byte)(_value + 1)) : this;
        }

        public Volume Decrease()
        {
            return _value != MinValue ? new Volume((byte)(_value - 1)) : this;
        }

        public Volume Clone()
        {
            return new Volume(_value);
        }

        public Volume Reset()
        {
            return new Volume(15);
        }
    }
}
