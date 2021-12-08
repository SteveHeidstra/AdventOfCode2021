using Kerstpuzzel.Sudoku;
using NUnit.Framework;

namespace KerstpuzzelTests.Sudoku
{
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void A_new_cell_has_value_0()
        {
            Cell cell = new Cell("1A", null);
            Assert.AreEqual(0, cell.Value);
        }

        [Test]
        public void Removing_8_values_assigns_a_value()
        {
            Block block = new Block("A", new Kerstpuzzel.Sudoku.Sudoku());
            Cell cell = new Cell("A2", block);
            cell.RemoveValue(1);
            Assert.IsFalse(cell.PossibleValues.Contains(1));
            cell.RemoveValue(2);
            cell.RemoveValue(3);
            cell.RemoveValue(5);
            cell.RemoveValue(6);
            cell.RemoveValue(7);
            cell.RemoveValue(8);
            Assert.AreEqual(0, cell.Value);
            cell.RemoveValue(9);
            Assert.AreEqual(4, cell.Value);
        }
       
    }
}
