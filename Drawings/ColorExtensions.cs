using Color = System.Drawing.Color;

namespace Common.Drawings
{
    public static class ColorExtensions
    {
        public static string ToHex(this Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

    }
}
