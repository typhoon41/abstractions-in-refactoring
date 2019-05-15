using System;

namespace TV___Step_4.Interfaces
{
    public interface ITimeManager
    {
        DateTime Get();
        void Set(DateTime dateTime);
    }
}
