using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SomeTools
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, format);

                return stream.ToArray();
            }
        }
    }
}
