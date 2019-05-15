using System;

namespace TV___Step_3.Interfaces
{
    public interface ITimeManager
    {
        DateTime Get();
        void Set(DateTime dateTime);
    }
}
