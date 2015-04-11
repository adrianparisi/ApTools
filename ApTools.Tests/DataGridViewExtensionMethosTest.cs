using ApTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace ApToolsTest
{
    [TestClass]
    public class DataGridViewExtensionMethosTest
    {
        private static DataGridView FakeDataGridView()
        {
            DataGridView grid = new DataGridView();
            grid.AutoGenerateColumns = false;

            grid.Columns.Add("C0", "C0");
            grid.Columns.Add("C1", "C1");
            grid.Columns.Add("C2", "C2");

            grid.Rows.Add("Cero.1", "", 2.1);
            grid.Rows.Add("", "", 2.2);
            grid.Rows.Add("Cero.3", "", null);

            foreach (DataGridViewColumn column in grid.Columns)
                column.Visible = true;

            return grid;
        }
        

        [TestMethod]
        public void HideEmptyColumnTest()
        {
            DataGridView grid = FakeDataGridView();
            grid.HideEmptyColumns();

            Assert.IsFalse(grid.Columns[1].Visible);
        }

        [TestMethod]
        public void NotHideNonEmptyColumnTest()
        {
            DataGridView grid = FakeDataGridView();
            grid.HideEmptyColumns();

            Assert.IsTrue(grid.Columns[0].Visible, "Column 0 is not visible");
            Assert.IsTrue(grid.Columns[2].Visible, "Column 2 is not visible");
        }
    }
}
