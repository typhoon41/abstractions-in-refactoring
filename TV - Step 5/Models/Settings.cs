using TV___Step_5.Builders;
using TV___Step_5.Interfaces;
using TV___Step_5.Interfaces.Network;
using TV___Step_5.Models.Language;
using TV___Step_5.Models.Network;
using TV___Step_5.Models.Picture;

namespace TV___Step_5.Models
{
    public class Settings
    {
        public AdvancedSettings Advanced { get; private set; }
        public DataSource Source { get; private set; }
        public INetworkManager NetworkManager { get; private set; }
        public UiLanguage SelectedLanguage { get; private set; }
        public IPictureSettings Picture { get; private set; }
        public ISubtitleSettings Subtitle { get; private set; }

        public Settings()
        {
            Reset();
        }

        public void Set(DataSource source)
        {
            Source = Source.Clone();
        }

        public void Set(ISubtitleSettings subtitle)
        {
            Subtitle = subtitle;
        }

        public void Change(INetwork network)
        {
            NetworkManager = new Manager(network);
        }

        public void Switch(string language)
        {
            SelectedLanguage = new UiLanguage(language);
        }

        public void Reset()
        {
            Source = new DataSource("VGA");
            Advanced = new AdvancedSettings();
            NetworkManager = new Manager(new None());
            SelectedLanguage = new UiLanguage("en");
            Picture = new PictureSettings();
            Subtitle = new SubtitleSettingsBuilder().Build();
        }
    }
}
