using TV___Step_2.Models.Language;
using TV___Step_2.Models.Subtitles;

namespace TV___Step_2.Interfaces
{
    public interface ISubtitleSettings
    {
        bool Enabled { get; }
        byte Size { get; }
        Color Color { get; }
        SubtitleLanguage Language { get; }
    }
}
