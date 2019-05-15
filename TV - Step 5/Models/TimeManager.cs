using System;
using TV___Step_5.Interfaces;

namespace TV___Step_5.Models
{
    public class TimeManager : ITimeManager
    {
        private DateTime _userDateTime;
        private DateTime _realDateTime;

        public TimeManager()
        {
            Reset();
        }

        public DateTime Get()
        {
            var now = DateTime.Now;
            var difference = now - _realDateTime;

            return _userDateTime.Add(difference);
        }

        public void Set(DateTime dateTime)
        {
            _realDateTime = DateTime.Now;
            _userDateTime = dateTime;
        }

        public void Reset()
        {
            _userDateTime = _realDateTime = DateTime.Now;
        }
    }
}
