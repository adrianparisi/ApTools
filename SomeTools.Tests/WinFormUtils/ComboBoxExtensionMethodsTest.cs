using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

            int expected = combo.Width;

            combo.Items.Add("extra large");
            combo.AutoSize();

            int actual = combo.Width;

            Assert.IsTrue(expected < actual);
        }

        [TestMethod]
        public void AvoidKeyLenghtToCalculateWidthTest()
        {
            ComboBox combo1 = new ComboBox();
            combo1.Items.Add(new KeyValuePair<int, string>(1, "same label"));
            combo1.ValueMember = "Key";
            combo1.DisplayMember = "Value";
            combo1.AutoSize();

            ComboBox combo2 = new ComboBox();
            combo2.Items.Add(new KeyValuePair<int, string>(1000, "same label"));
            combo2.ValueMember = "Key";
            combo2.DisplayMember = "Value";
            combo2.AutoSize();

            Assert.IsTrue(combo1.Width == combo2.Width);
        }
    }
}
