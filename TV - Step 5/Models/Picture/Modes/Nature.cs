using TV___Step_5.Models.Data;

namespace TV___Step_5.Models.Picture.Modes
{
    public class Nature : DisplayMode
    {
        public override Percentage AdjustBrightness(Percentage brightness)
        {
            return brightness < 40 ? new Percentage(50) : base.AdjustBrightness(brightness);
        }

        public override Percentage AdjustSharpness(Percentage sharpness)
        {
            return sharpness < 20 ? new Percentage(20) : base.AdjustSharpness(sharpness);
        }
    }
}
