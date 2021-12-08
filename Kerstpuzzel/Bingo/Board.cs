using System;
using System.Linq;

namespace Kerstpuzzel.Bingo
{
    public class Board
    {
        private readonly int?[,] _myGrid;
        
        public Board()
        {
            _myGrid = new int?[5, 5];
        }
       
        private int?[] GetGridRow(int iRow)
        {
            return new int?[] { _myGrid[0, iRow], _myGrid[1, iRow], _myGrid[2, iRow], _myGrid[3, iRow], _myGrid[4, iRow] };
        }

        public void SetGridRow(string[] myval, int iRow)
        {
            if (myval != null)
            {
                _myGrid[0, iRow] = (int?)Convert.ToInt64(myval[0]);
                _myGrid[1, iRow] = (int?)Convert.ToInt64(myval[1]);
                _myGrid[2, iRow] = (int?)Convert.ToInt64(myval[2]);
                _myGrid[3, iRow] = (int?)Convert.ToInt64(myval[3]);
                _myGrid[4, iRow] = (int?)Convert.ToInt64(myval[4]);
            }
        }

        public void SetGridRow(int?[] myval, int iRow)
        {
            if (myval != null)
            {
                _myGrid[0, iRow] = myval[0];
                _myGrid[1, iRow] = myval[1];
                _myGrid[2, iRow] = myval[2];
                _myGrid[3, iRow] = myval[3];
                _myGrid[4, iRow] = myval[4];
            }
        }

        private int?[] GetGridCol(int iCol)
        {
            return new int?[] { _myGrid[iCol, 4], _myGrid[iCol, 3], _myGrid[iCol, 2], _myGrid[iCol, 1], _myGrid[iCol, 0] };
        }

        private void SetGridCol(int?[] myval, int iCol)
        {
            if (myval != null)
            {
                _myGrid[iCol, 4] = myval[0];
                _myGrid[iCol, 3] = myval[1];
                _myGrid[iCol, 2] = myval[2];
                _myGrid[iCol, 1] = myval[3];
                _myGrid[iCol, 0] = myval[4];
            }
        }

        public bool MarkNumber(int number)
        {
            for (int iRow = 0; iRow < 5; iRow++)
            {
                for (int iCol = 0; iCol < 5; iCol++)
                {
                    if (_myGrid[iCol, iRow] == number)
                    {
                        _myGrid[iCol, iRow] = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckForBingo()
        {
            for (int iRow = 0; iRow < 5; iRow++)
            {
                if (!GetGridRow(iRow).Any(x => x != null))
                {
                    return true;
                };
            }
            for (int iCol = 0; iCol < 5; iCol++)
            {
                if (!GetGridCol(iCol).Any(x => x != null))
                {
                    return true;
                };
            }

            return false;
        }

        public new string ToString()
        {

            return _myGrid[0,0] + '|' + _myGrid[1,0] + '|' + _myGrid[2, 0] + '|' + _myGrid[3, 0] + '|' + _myGrid[4, 0] + Environment.NewLine +
                _myGrid[0, 1] + '|' + _myGrid[1, 1] + '|' + _myGrid[2, 1] + '|' + _myGrid[3, 1] + '|' + _myGrid[4, 1] + Environment.NewLine +
                _myGrid[0, 2] + '|' + _myGrid[1, 2] + '|' + _myGrid[2, 2] + '|' + _myGrid[3, 2] + '|' + _myGrid[4, 2] + Environment.NewLine +
                _myGrid[0, 3] + '|' + _myGrid[1, 3] + '|' + _myGrid[2, 3] + '|' + _myGrid[3, 3] + '|' + _myGrid[4, 3] + Environment.NewLine +
                _myGrid[0, 4] + '|' + _myGrid[1, 4] + '|' + _myGrid[2, 4] + '|' + _myGrid[3, 4] + '|' + _myGrid[4, 4] + Environment.NewLine 
                ;
        }

        public int? AoCBoardScore()
        {

            return GetGridRow(0).Sum() + GetGridRow(1).Sum() + GetGridRow(2).Sum() + GetGridRow(3).Sum() + GetGridRow(4).Sum();
        }
    }
}