using System;

namespace TV___Step_4.Models.Language
{
    public class SubtitleLanguage
    {
        public string Name { get; }

        public SubtitleLanguage(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentException(nameof(name)) : name;
        }
    }
}
