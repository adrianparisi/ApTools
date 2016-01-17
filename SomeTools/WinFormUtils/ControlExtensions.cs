using System.Drawing;
using System.Windows.Forms;

namespace SomeTools.ExtensionMethods
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Centers the specified control inside his parent.
        /// </summary>
        public static void Center(this Control control)
        {
            control.Center(control.Parent);
        }

        /// <summary>
        /// Centers the specified control regard the reference.
        /// </summary>
        /// <param name="reference">Reference to center the control.</param>
        public static void Center(this Control control, Control reference)
        {
            control.Location = new Point((reference.Width - control.Width) / 2, control.Location.Y);
        }
    }
}
