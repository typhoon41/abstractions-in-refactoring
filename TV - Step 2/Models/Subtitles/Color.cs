﻿using System;

namespace TV___Step_2.Models.Subtitles
{
    public class Color
    {
        public string Name { get; }

        public Color(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException(nameof(name)) : name;
        }
    }
}
