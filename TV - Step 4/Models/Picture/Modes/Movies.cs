using TV___Step_4.Models.Data;

namespace TV___Step_4.Models.Picture.Modes
{
    public class Movies : DisplayMode
    {
        public override Percentage AdjustBrightness(Percentage brightness)
        {
            return brightness > 50 ? new Percentage(30) : base.AdjustBrightness(brightness);
        }

        public override Percentage AdjustSharpness(Percentage sharpness)
        {
            return sharpness > 70 ? new Percentage(70) : base.AdjustSharpness(sharpness);
        }
    }
}
