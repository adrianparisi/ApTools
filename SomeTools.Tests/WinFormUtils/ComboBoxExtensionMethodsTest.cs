using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace SomeTools.Tests.ExtensionMethods
{
    [TestClass]
    public class ComboBoxExtensionMethodsTest
    {
        [TestMethod]
        public void SmallIsSmallerThanExtraLargeTest()
        {
            ComboBox combo1 = new ComboBox();
            combo1.Items.Add("small");
            combo1.AutoSize();


            ComboBox combo2 = new ComboBox();
            combo2.Items.Add("extra large");
            combo2.AutoSize();

            Assert.IsTrue(combo1.Width < combo2.Width);
        }

        [TestMethod]
        public void RecalculateSizeAfterAddItemsTest()
        {
            ComboBox combo = new ComboBox();
            combo.Items.Add("small");
            combo.AutoSize();

            int width = combo.Width;

            combo.Items.Add("extra large");
            combo.AutoSize();

            Assert.IsTrue(width < combo.Width);
        }
    }
}
