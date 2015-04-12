using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing.Imaging;
using System.Linq;

namespace SomeTools.Tests.ExtensionMethods
{
    [TestClass]
    public class ImageExtensionsTest
    {
        [TestMethod]
        public void ConvertImageToArrayTest()
        {
            byte[] array = Resources.Flag.ToByteArray(ImageFormat.Png);

            Assert.IsTrue(array.Count() > 0);
        }
    }
}
