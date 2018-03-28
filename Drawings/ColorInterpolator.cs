using System;
using Color = System.Drawing.Color;

namespace Common.Drawings
{
    // http://stackoverflow.com/questions/1236683/color-interpolation-between-3-colors-in-net
    public static class ColorInterpolator
    {
        delegate byte ComponentSelector(Color color);
        static ComponentSelector _redSelector = color => color.R;
        static ComponentSelector _greenSelector = color => color.G;
        static ComponentSelector _blueSelector = color => color.B;

        public static Color Lerp(
            Color endPoint1,
            Color endPoint2,
            double lambda)
        {
            if (lambda < 0 || lambda > 1)
            {
                throw new ArgumentOutOfRangeException("lambda");
            }
            Color color = Color.FromArgb(
                InterpolateComponent(endPoint1, endPoint2, lambda, _redSelector),
                InterpolateComponent(endPoint1, endPoint2, lambda, _greenSelector),
                InterpolateComponent(endPoint1, endPoint2, lambda, _blueSelector)
            );

            return color;
        }

        public static Color Lerp(double lambda, params Color[] colors)
        {
            double scaled = lambda * (double)(colors.Length - 1);
            int index = (int)scaled;

            Color start = colors[index];
            Color end = colors[index + 1];

            double m = (1.0 / (colors.Length - 1));

            return Lerp(start, end, (lambda % m) / m);
        }

        private static byte InterpolateComponent(
            Color endPoint1,
            Color endPoint2,
            double lambda,
            ComponentSelector selector)
        {
            return (byte)(selector(endPoint1)
                + (selector(endPoint2) - selector(endPoint1)) * lambda);
        }
    }
}
