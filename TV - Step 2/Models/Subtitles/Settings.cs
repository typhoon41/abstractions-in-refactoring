using System;
using TV___Step_2.Interfaces;
using TV___Step_2.Models.Language;

namespace TV___Step_2.Models.Subtitles
{
    public class Settings : ISubtitleSettings
    {
        private const byte MinSize = 8;

        public bool Enabled { get; }
        public byte Size { get; }
        public Color Color { get; }
        public SubtitleLanguage Language { get; }

        public Settings(bool enabled, byte size, Color color, SubtitleLanguage language)
        {
            Size = size >= MinSize ? size : throw new ArgumentException(nameof(size));
            Enabled = enabled;
            Color = color;
            Language = language;
        }
    }
}
