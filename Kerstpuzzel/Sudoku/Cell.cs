using System.Collections.Generic;
using System.Linq;

namespace Kerstpuzzel.Sudoku
{
    public class Cell
    {
        public Cell(string id, Block block)
        {
            _possibleValues = new HashSet<int>
            {
                1, 2,3,4,5,6,7,8,9
            };
            //Id will be Blockletter + number: A1, A2, A3 etc
            ID = id;
            Block = block;
            _value = 0;
        }

        public string ID { get; private set; }

        private readonly HashSet<int> _possibleValues;
        public Block Block { get; private set; }

        public int Row { get; set; }
        public int Col { get; set; }

        public void RemoveValue(int i)
        {
            _possibleValues.Remove(i);
            if (_possibleValues.Count == 1)
            {
                Value = _possibleValues.First();
            }
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value;
                Block.CellGotValue(this);
            }
        }

        public HashSet<int> PossibleValues { get { return _possibleValues;  } }
    }
}
