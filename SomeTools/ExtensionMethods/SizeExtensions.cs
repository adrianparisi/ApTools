using System.Drawing;

namespace SomeTools
{
    public static class SizeExtensions
    {
        public static Size Divide(this Size size, int divider)
        {
            return new Size(size.Width / divider, size.Height / divider);
        }

        public static Size Multiply(this Size size, int multiplier)
        {
            return new Size(size.Width * multiplier, size.Height * multiplier);
        }
    }
}
