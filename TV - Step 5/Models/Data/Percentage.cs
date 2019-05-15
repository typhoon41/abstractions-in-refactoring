using System;

namespace TV___Step_5.Models.Data
{
    public sealed class Percentage : BasePercentage
    {
        public override ushort MaxValue => 100;
        public override ushort Value { get; }

        public Percentage(byte percentage)
        {
            Value = percentage <= MaxValue ? percentage : throw new ArgumentOutOfRangeException(nameof(percentage));
        }
    }
}
