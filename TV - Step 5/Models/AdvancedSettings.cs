using TV___Step_5.Models.Data;

namespace TV___Step_5.Models
{
    public class AdvancedSettings
    {
        public bool AllowedRemoteControl { get; set; } = false;
        public bool AllowedAudioVideoShare { get; set; } = false;
        public bool DynamicBassOn { get; set; } = false;
        public SoundEqualizer Equalizer { get; private set; } = new SoundEqualizer("Movie");
        public ZoomPercentage ZoomLevel { get; private set; } = new ZoomPercentage(100);

        public void Set(SoundEqualizer equalizer)
        {
            Equalizer = new SoundEqualizer(equalizer.Name);
        }

        public void Set(ZoomPercentage zoomLevel)
        {
            ZoomLevel = new ZoomPercentage(zoomLevel.Value);
        }
    }
}
