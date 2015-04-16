using System;
using System.Windows.Forms;

namespace SomeTools
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Sets as invisible columns containing all empty rows.
        /// </summary>
        public static void HideEmptyColumns(this DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
                if (column.IsEmpty())
                    column.Visible = false;
        }

        /// <summary>
        /// Determines whether is an empty column.
        /// </summary>
        public static bool IsEmpty(this DataGridViewColumn column)
        {
            foreach (DataGridViewRow row in column.DataGridView.Rows)
            {
                object cell = row.Cells[column.Index].Value;

                if (cell != null && cell.ToString() != String.Empty)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the value of the cell is the default date.
        /// </summary>
        public static bool IsDefaultDate(this DataGridViewCell cell)
        {
            DateTime date;

            bool parse = DateTime.TryParse(cell.Value.ToString(), out date);

            return parse && date == new DateTime();
        }
    }
}
