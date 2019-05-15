using System;
using TV___Step_4.Interfaces;

namespace TV___Step_4.Models
{
    public class TimeManager : ITimeManager
    {
        private DateTime _userDateTime = DateTime.Now;
        private DateTime _realDateTime = DateTime.Now;

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
    }
}
