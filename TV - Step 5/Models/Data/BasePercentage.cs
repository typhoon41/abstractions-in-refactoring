namespace TV___Step_5.Models.Data
{
    public abstract class BasePercentage
    {
        public abstract ushort MaxValue { get; }

        public abstract ushort Value { get; }

        public static implicit operator ushort(BasePercentage percentage)
        {
            return percentage.Value;
        }
    };
}
