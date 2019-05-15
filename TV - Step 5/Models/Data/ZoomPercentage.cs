using System;

namespace TV___Step_5.Models.Data
{
    public class ZoomPercentage : BasePercentage
    {
        public sealed override ushort MaxValue => 1600;
        public override ushort Value { get; }

        public ZoomPercentage(ushort percentage)
        {
            Value = percentage <= MaxValue ? percentage : throw new ArgumentOutOfRangeException(nameof(percentage));
        }
    }
}
