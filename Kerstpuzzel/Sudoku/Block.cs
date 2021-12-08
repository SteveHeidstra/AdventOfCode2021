using System.Collections.Generic;
using System.Linq;

namespace Kerstpuzzel.Sudoku
{
    public class Block
    {
        //Block is made up of 9 cells:
        // 1  2  3
        // 4  5  6
        // 7  8  9

        public Block(string id, Sudoku sudoku)
        {
            ID = id;
            cells = new HashSet<Cell>();
            _sudoku = sudoku;

            //Generate 9 cells for this block
            for (int i = 1; i <= 9; i++)
            {
                cells.Add(new Cell(id + i, this)
                {
                    Row = _sudoku.GetRowNumber(i),
                    Col = _sudoku.GetColNumber(i)
                });
            }
        }

        public int Row { get; set; }
        public int Col { get; set; }
              
        private readonly Sudoku _sudoku;

        public string ID { get; private set; }

        private readonly HashSet<Cell> cells;

        /// <summary>
        /// If a cell in this block was solved then the other cells can not contain the same value
        /// It gets stricken from the possible values of the cells
        /// </summary>
        /// <param name="solvedCell"></param>
        internal void CellGotValue(Cell solvedCell)
        {
            foreach (Cell cell in cells)
            {
                if (cell != solvedCell)
                {
                    cell.RemoveValue(solvedCell.Value);
                }
            }

            Sudoku.CellGotValue(solvedCell);
        }

        /// <summary>
        /// Find a specific cell by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Cell</returns>
        public Cell GetCell(string id)
        {
            return cells.First(x => x.ID == id);
        }

        public HashSet<Cell> Cells
        {
            get { return cells; }
        }
    }
}
