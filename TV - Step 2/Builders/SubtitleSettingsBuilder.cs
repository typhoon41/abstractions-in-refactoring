using TV___Step_2.Interfaces;
using TV___Step_2.Models;
using TV___Step_2.Models.Language;
using TV___Step_2.Models.Subtitles;

namespace TV___Step_2.Builders
{
    public class SubtitleSettingsBuilder
    {
        private byte _size = 36;
        private bool _enabled = false;
        private Color _color = new Color("white");
        private SubtitleLanguage _language = new SubtitleLanguage("en");

        public SubtitleSettingsBuilder WithSize(byte size)
        {
            _size = size;
            return this;
        }

        public SubtitleSettingsBuilder WithEnabled(bool enabled)
        {
            _enabled = enabled;
            return this;
        }

        public SubtitleSettingsBuilder WithColor(Color color)
        {
            _color = color;
            return this;
        }

        public SubtitleSettingsBuilder WithLanguage(SubtitleLanguage language)
        {
            _language = language;
            return this;
        }

        public ISubtitleSettings Build()
        {
            return new Settings(_enabled, _size, _color, _language);
        }
    }
}
