using ApTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace ApToolsTest
{
    [TestClass]
    public class DataGridViewExtensionMethosTest
    {
        [TestMethod]
        public void HideEmptyColumnTest()
        {
            DataGridView grid = GetDataGridView();
            grid.HideEmptyColumns();

            Assert.IsFalse(grid.Columns[1].Visible);
        }

        [TestMethod]
        public void NotHideNonEmptyColumnTest()
        {
            DataGridView grid = GetDataGridView();
            grid.HideEmptyColumns();

            Assert.IsTrue(grid.Columns[0].Visible);
            Assert.IsTrue(grid.Columns[2].Visible);
        }

        private static DataGridView GetDataGridView()
        {
            DataGridView grid = new DataGridView();
            DataGridViewRow row = new DataGridViewRow();

            grid.AutoGenerateColumns = false;

            grid.Columns.Add("C0", "C0");
            grid.Columns.Add("C1", "C1");
            grid.Columns.Add("C2", "C2");

            foreach (DataGridViewColumn column in grid.Columns)
                column.Visible = true;

            grid.Rows.Add("Cero.1", "", 2.1);
            grid.Rows.Add("Cero.2", "", 2.2);
            grid.Rows.Add("Cero.3", "", 2.3);
            
            return grid;
        }
    }
}
