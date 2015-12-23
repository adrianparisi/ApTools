using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomeTools.WinFormUtils
{
    /// <summary>
    /// Group radio buttons without be on the same group box.
    /// </summary>
    public class RadioGroup
    {
        private List<RadioButton> radioButtons = new List<RadioButton>();


        /// <summary>
        /// Add radio buttons to group. Must be after InitializeComponent.
        /// </summary>
        public void Add(RadioButton radioButton)
        {
            this.radioButtons.Add(radioButton);
            this.Bind(radioButton);
            this.radioButtons[0].TabStop = true;
        }

        public void Add(IEnumerable<RadioButton> radioButtons)
        {
            this.radioButtons.AddRange(radioButtons);

            foreach (RadioButton radioButton in radioButtons)
                this.Bind(radioButton);

            this.radioButtons[0].TabStop = true;
        }

        private void Bind(RadioButton radioButton)
        {
            radioButton.TabStop = false;
            radioButton.KeyUp += radioButton_KeyUp;
            radioButton.CheckedChanged += radioButton_CheckedChanged;
        }

        private void radioButton_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            RadioButton radioButton = (RadioButton)sender;
            int index = this.radioButtons.IndexOf(radioButton);

            if (e.KeyCode == Keys.Down)
            {
                index++;

                if (index >= this.radioButtons.Count)
                    index = 0;

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                index--;

                if (index < 0)
                    index = this.radioButtons.Count - 1;

                e.Handled = true;
            }

            radioButton = this.radioButtons[index];
            radioButton.Focus();
            radioButton.Select();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                foreach (RadioButton rb in this.radioButtons)
                {
                    if (!rb.Equals(radioButton))
                        rb.Checked = false;
                }
            }
        }
    }
}
