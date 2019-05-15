using System;

namespace TV___Step_5.Interfaces
{
    public interface ITimeManager
    {
        DateTime Get();
        void Set(DateTime dateTime);
        void Reset();
    }
}
