using System;

namespace TV___Step_1.Models.Data
{
    public struct Percentage
    {
        public const int MaxValue = 100;

        private readonly byte _value;

        public Percentage(byte percentage)
        {
            _value = percentage <= MaxValue ? percentage : throw new ArgumentOutOfRangeException(nameof(percentage));
        }

        public static implicit operator byte(Percentage percentage)
        {
            return percentage._value;
        }
    }
}
