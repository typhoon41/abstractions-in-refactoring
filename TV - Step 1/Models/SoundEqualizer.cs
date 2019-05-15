using System;

namespace TV___Step_1.Models
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
