using System.Collections.Generic;
using System.Linq;

namespace Kerstpuzzel.Sudoku
{
    public class Sudoku
    {
        //Sudoku is made up of 9 blocks:
        // A  B  C
        // D  E  F
        // G  H  I

        public Sudoku()
        {
            blocks = new HashSet<Block>();

            for (int i = 1; i <= 9; i++)
            {
                blocks.Add(new Block(Alfabet.A1B2.First(x => x.Value == i).Key.ToUpper(), this)
                {
                    Row = GetRowNumber(i),
                    Col = GetColNumber(i)
                });
            }
        }

        internal int GetRowNumber(int i)
        {
            var result = 0;
            switch (i)
            {
                case 1:
                case 2:
                case 3:
                    result = 1;
                    break;
                case 4:
                case 5:
                case 6:
                    result = 2;
                    break;
                case 7:
                case 8:
                case 9:
                    result = 3;
                    break;
                default:
                    break;
            }
            return result;
        }

        internal int GetColNumber(int i)
        {
            var result = 0;
            switch (i)
            {
                case 1:
                case 4:
                case 7:
                    result = 1;
                    break;
                case 2:
                case 5:
                case 8:
                    result = 2;
                    break;
                case 3:
                case 6:
                case 9:
                    result = 3;
                    break;
                default:
                    break;
            }
            return result;
        }


        private static HashSet<Block> blocks;
        public HashSet<Block> Blocks { get { return blocks; } }

        internal static void CellGotValue(Cell solvedCell)
        {
            foreach (Block block in blocks.Where(x => x.Row == solvedCell.Block.Row || x.Col == solvedCell.Block.Col))
            {
                foreach (Cell cell in block.Cells)
                {
                    if ((block.Row == solvedCell.Block.Row && cell.Row == solvedCell.Row) ||
                        (block.Col == solvedCell.Block.Col && cell.Col == solvedCell.Col) ||
                        cell.ID != solvedCell.ID)
                    {
                        cell.RemoveValue(solvedCell.Value);
                    }
                }
            }
        }        
    }
}
