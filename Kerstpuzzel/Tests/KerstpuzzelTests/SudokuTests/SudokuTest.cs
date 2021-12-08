using NUnit.Framework;
using Kerstpuzzel.Sudoku;
using System.Linq;

namespace KerstpuzzelTests.Sudoku
{
    [TestFixture]
    public class SudokuTest
    {
        [Test]
        public void Sudoku_bevat_9_blokken()
        {
            Kerstpuzzel.Sudoku.Sudoku sudo = new Kerstpuzzel.Sudoku.Sudoku();
            Assert.AreEqual(9, sudo.Blocks.Count);
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "A"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "B"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "C"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "D"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "E"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "F"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "G"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "H"));
            Assert.IsTrue(sudo.Blocks.Any(x => x.ID == "I"));            
        }  
        
        [Test]
        public void Sudoku_maakt_goede_blokken()
        {
            Kerstpuzzel.Sudoku.Sudoku sudo = new Kerstpuzzel.Sudoku.Sudoku();
            foreach (Block block in sudo.Blocks)
            {
                switch(block.ID)                   
                {
                    case "A":
                        Assert.AreEqual(1, block.Row);
                        Assert.AreEqual(1, block.Col);
                        break;
                    case "B":
                        Assert.AreEqual(1, block.Row);
                        Assert.AreEqual(2, block.Col);
                        break;
                    case "C":
                        Assert.AreEqual(1, block.Row);
                        Assert.AreEqual(3, block.Col);
                        break;
                    case "D":
                        Assert.AreEqual(2, block.Row);
                        Assert.AreEqual(1, block.Col);
                        break;
                    case "E":
                        Assert.AreEqual(2, block.Row);
                        Assert.AreEqual(2, block.Col);
                        break;
                    case "F":
                        Assert.AreEqual(2, block.Row);
                        Assert.AreEqual(3, block.Col);
                        break;
                    case "G":
                        Assert.AreEqual(3, block.Row);
                        Assert.AreEqual(1, block.Col);
                        break;
                    case "H":
                        Assert.AreEqual(3, block.Row);
                        Assert.AreEqual(2, block.Col);
                        break;
                    case "I":
                        Assert.AreEqual(3, block.Row);
                        Assert.AreEqual(3, block.Col);
                        break;
                    default:
                        break;
                }
            }
        }

        [Test]
        public void Sudoku_werkt_rijen_en_blokken_bij_als_opgelost()
        {
            Kerstpuzzel.Sudoku.Sudoku sudo = new Kerstpuzzel.Sudoku.Sudoku();
            sudo.Blocks.First(x => x.ID == "E").GetCell("E3").Value = 6;

            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "B").GetCell("B3").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "B").GetCell("B6").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "B").GetCell("B9").PossibleValues.Contains(6));

            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "H").GetCell("H3").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "H").GetCell("H6").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "H").GetCell("H9").PossibleValues.Contains(6));

            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "D").GetCell("D1").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "D").GetCell("D2").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "D").GetCell("D3").PossibleValues.Contains(6));

            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "F").GetCell("F1").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "F").GetCell("F2").PossibleValues.Contains(6));
            Assert.IsFalse(sudo.Blocks.First(x => x.ID == "F").GetCell("F3").PossibleValues.Contains(6));
        }
    }
}
