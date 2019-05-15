using System;

namespace TV___Step_2.Models
{
    public class DisplayMode
    {
        public string Name { get; }

        public DisplayMode(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException(nameof(name)) : name;
        }
    }
}
