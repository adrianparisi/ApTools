using System;
using System.Windows.Forms;

namespace ApTools
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Sets as invisible columns containing all empty rows.
        /// </summary>
        public static void HideEmptyColumns(this DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
                if (DataGridViewExtensions.IsEmptyColumn(grid, column.Index))
                    grid.Columns[column.Index].Visible = false;
        }

        private static bool IsEmptyColumn(DataGridView grid, int index)
        {
            foreach (DataGridViewRow row in grid.Rows)
                if (row.Cells[index].Value == null ||
                    row.Cells[index].Value.ToString() == String.Empty ||
                    row.Cells[index].IsDefaultDate())
                    return true;

            return false;
        }

        public static bool IsDefaultDate(this DataGridViewCell cell)
        {
            DateTime date;

            bool parse = DateTime.TryParse(cell.Value.ToString(), out date);

            return parse && date == new DateTime();
        }
    }
}
