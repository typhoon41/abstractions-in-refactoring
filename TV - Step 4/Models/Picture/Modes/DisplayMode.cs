using TV___Step_4.Models.Data;

namespace TV___Step_4.Models.Picture.Modes
{
    public abstract class DisplayMode
    {
        public virtual Percentage AdjustBrightness(Percentage brightness)
        {
            return brightness;
        }

        public virtual Percentage AdjustSharpness(Percentage sharpness)
        {
            return sharpness;
        }
    }
}
