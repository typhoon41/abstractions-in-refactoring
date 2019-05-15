using System;
using TV___Step_5.Interfaces;
using TV___Step_5.Models.Data;
using TV___Step_5.Models.Picture.Modes;

namespace TV___Step_5.Models.Picture
{
    public class PictureSettings : IPictureSettings
    {
        public Modes.DisplayMode Mode { get; private set; } = new Nature();
        public Percentage Brightness { get; private set; } = new Percentage(60);
        public Percentage Sharpness { get; private set; } = new Percentage(70);
        public Percentage Contrast { get; private set; } = new Percentage(40);

        public PictureSettings()
        {

        }

        public void Switch(Modes.DisplayMode mode)
        {
            Mode = mode ?? throw new ArgumentNullException(nameof(mode));
            Brightness = Mode.AdjustBrightness(Brightness);
            Sharpness = Mode.AdjustSharpness(Sharpness);
        }

        public void SetBrightness(byte value)
        {
            Brightness = Mode.AdjustBrightness(new Percentage(value));
        }

        public void SetSharpness(byte value)
        {
            Sharpness = Mode.AdjustSharpness(new Percentage(value));
        }

        public void SetContrast(byte value)
        {
            Contrast = new Percentage(value);
        }
    }
}
