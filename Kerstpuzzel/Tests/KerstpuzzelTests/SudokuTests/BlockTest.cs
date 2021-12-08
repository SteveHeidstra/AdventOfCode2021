using Kerstpuzzel.Sudoku;
using NUnit.Framework;

namespace KerstpuzzelTests.Sudoku
{
    [TestFixture]
    public class BlockTest
    {
        [Test]
        public void Solved_Cell_will_update_block()
        {
            Block block = new Block("A", new Kerstpuzzel.Sudoku.Sudoku());
            block.GetCell("A3").Value = 2;

            foreach (Cell cell in block.Cells)
            {
                if (cell.ID != "A3")
                {
                    Assert.IsFalse(cell.PossibleValues.Contains(2));
                }
            }
        }


        [Test]
        public void Block_generates_9_Cells()
        {
             Block block = new Block("Z", new Kerstpuzzel.Sudoku.Sudoku());
            Assert.AreEqual(9, block.Cells.Count);

            Assert.AreEqual(1, block.GetCell("Z1").Row);
            Assert.AreEqual(1, block.GetCell("Z1").Col);

            Assert.AreEqual(1, block.GetCell("Z2").Row);
            Assert.AreEqual(2, block.GetCell("Z2").Col);

            Assert.AreEqual(1, block.GetCell("Z3").Row);
            Assert.AreEqual(3, block.GetCell("Z3").Col);

            Assert.AreEqual(2, block.GetCell("Z4").Row);
            Assert.AreEqual(1, block.GetCell("Z4").Col);

            Assert.AreEqual(2, block.GetCell("Z5").Row);
            Assert.AreEqual(2, block.GetCell("Z5").Col);

            Assert.AreEqual(2, block.GetCell("Z6").Row);
            Assert.AreEqual(3, block.GetCell("Z6").Col);

            Assert.AreEqual(3, block.GetCell("Z7").Row);
            Assert.AreEqual(1, block.GetCell("Z7").Col);

            Assert.AreEqual(3, block.GetCell("Z8").Row);
            Assert.AreEqual(2, block.GetCell("Z8").Col);

            Assert.AreEqual(3, block.GetCell("Z9").Row);
            Assert.AreEqual(3, block.GetCell("Z9").Col);

        }

    }
}
