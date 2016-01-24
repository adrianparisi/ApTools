using System.Windows.Forms;

namespace SomeTools
{
    public static class ComboBoxExtensions
    {
        /// <summary>
        /// Resize the width based on the largest item.
        /// </summary>
        public static void AutoSize(this ComboBox comboBox)
        {
            int current;
            int maximum = 0;

            foreach (var item in comboBox.Items)
            {
                current = TextRenderer.MeasureText(comboBox.GetItemText(item), comboBox.Font).Width;

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
