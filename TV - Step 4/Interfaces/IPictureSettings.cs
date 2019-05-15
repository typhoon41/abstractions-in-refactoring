using TV___Step_4.Models.Data;

namespace TV___Step_4.Interfaces
{
    public interface IPictureSettings
    {
        Models.Picture.Modes.DisplayMode Mode { get; }
        Percentage Brightness { get; }
        Percentage Sharpness { get; }
        Percentage Contrast { get; }
        void Switch(Models.Picture.Modes.DisplayMode mode);
        void SetBrightness(byte value);
        void SetSharpness(byte value);
        void SetContrast(byte value);
    }
}
