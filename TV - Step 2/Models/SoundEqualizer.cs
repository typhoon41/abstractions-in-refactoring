﻿using System;

namespace TV___Step_2.Models
{
    public class SoundEqualizer
    {
        public string Name { get; }

        public SoundEqualizer(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException(nameof(name)) : name;
        }
    }
}
