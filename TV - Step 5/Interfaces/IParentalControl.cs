﻿using System.Collections.Generic;
using TV___Step_5.Models.Channel;

namespace TV___Step_5.Interfaces
{
    public interface IParentalControl
    {
        void Set(string password);
        void Add(IEnumerable<Channel> channels);
        void Remove(Channel channel);
    }
}
