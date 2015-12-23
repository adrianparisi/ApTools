using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeTools.WinFormUtils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomeTools.Tests.WinFormUtils
{
    [TestClass]
    public class RadioGroupTest
    {
        [TestMethod]
        public void GroupRadioButtonsSeparetedContructionTest()
        {
            UserControl control1 = new UserControl();
            RadioButton button1 = new RadioButton();
            control1.Controls.Add(button1);

            UserControl control2 = new UserControl();
            RadioButton button2 = new RadioButton();
            control2.Controls.Add(button2);

            RadioGroup group = new RadioGroup();
            group.Add(button1);
            group.Add(button2);

            button1.Checked = true;
            button2.Checked = true;

            Assert.IsFalse(button1.Checked);
        }

        [TestMethod]
        public void GroupRadioButtonsListConstructionTest()
        {
            UserControl control1 = new UserControl();
            RadioButton button1 = new RadioButton();
            control1.Controls.Add(button1);

            UserControl control2 = new UserControl();
            RadioButton button2 = new RadioButton();
            control2.Controls.Add(button2);

            RadioGroup group = new RadioGroup();
            group.Add(new List<RadioButton>() { button1, button2 });

            button1.Checked = true;
            button2.Checked = true;

            Assert.IsFalse(button1.Checked);
        }
    }
}
