using System.Windows.Forms;

namespace SomeTools
{
    public static class ComboBoxExtensions
    {
        public static void AutoSize(this ComboBox comboBox)
        {
            int current;
            int maximum = 0;

            foreach (object text in comboBox.Items)
            {
                current = TextRenderer.MeasureText(text.ToString(), comboBox.Font).Width;

                if (current > maximum)
                    maximum = current;
            }

            int width = maximum + SystemInformation.VerticalScrollBarWidth;

            if (comboBox.Width != width)
            { 
                comboBox.Width = width;
                comboBox.Refresh();
            }
        }
    }
}
