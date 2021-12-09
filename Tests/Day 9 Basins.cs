using Kerstpuzzel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC2021
{
    [TestFixture]
    class Day_9_Basins
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public void FirstFindTheLowpoints()
        {
            string[] file = BestandHelper.Readfile(@"Input\D9P2.txt");
            List<string> bla = new List<string>();

            List<Tuple<int, int>> lowPoints = new List<Tuple<int, int>>();

            for (int iRow = 0; iRow < file.Length; iRow++)
            {
                for (int iCol = 0; iCol < file.First().Length; iCol++)
                {
                    int currentPoint = file[iRow][iCol];

                    //int up = file[Math.Max(iRow - 1, 0)][iCol];
                    int up = iRow == 0 ? int.MaxValue : file[iRow - 1][iCol];
                    int down = iRow == file.Length - 1 ? int.MaxValue : file[iRow + 1][iCol];
                    int left = iCol == 0 ? int.MaxValue : file[iRow][iCol - 1];
                    int right = iCol == file[iRow].Length - 1 ? int.MaxValue : file[iRow][iCol + 1];


                    if (currentPoint < new[] { up, down, left, right }.Min())
                    {
                        lowPoints.Add(Tuple.Create(iRow, iCol));
                    }
                }
            }

            int count = 0;
            foreach (Tuple<int, int> coords in lowPoints)
            {
                count += int.Parse(file[coords.Item1][coords.Item2].ToString()) + 1;
            }

            Assert.AreEqual(512, count);
        }

        [Test]
        public void MapTheAreas()
        {
            string[] file = BestandHelper.Readfile(@"Input\D9P2.txt");

            List<Location> lowPoints = new List<Location>();

            for (int iRow = 0; iRow < file.Length; iRow++)
            {
                for (int iCol = 0; iCol < file.First().Length; iCol++)
                {
                    int currentPoint = file[iRow][iCol];

                    int up = iRow == 0 ? int.MaxValue : file[iRow - 1][iCol];
                    int down = iRow == file.Length - 1 ? int.MaxValue : file[iRow + 1][iCol];
                    int left = iCol == 0 ? int.MaxValue : file[iRow][iCol - 1];
                    int right = iCol == file[iRow].Length - 1 ? int.MaxValue : file[iRow][iCol + 1];


                    if (currentPoint < new[] { up, down, left, right }.Min())
                    {
                        lowPoints.Add(new Location(iRow, iCol, int.Parse(file[iRow][iCol].ToString())));
                    }
                }
            }

            List<Basin> basins = new List<Basin>();
            foreach (Location coords in lowPoints)
            {
                //Map the area recursive
                Basin basin = new Basin();
                basin = mapBasinRecurs(coords, basin, file);
                basins.Add(basin);
            }

            var y = basins.OrderByDescending(x => x.Size).Take(3);
            int prod = 1;
            foreach ( Basin b in y)
            {
                prod = prod * b.Size;
            }
            Console.WriteLine(prod);
            Assert.AreEqual(prod, 1600104);


        }

        private Basin mapBasinNonRecus(Location currentPoint, Basin doNotUse, string[] file)
        {
            Basin myBase = new Basin();
            myBase.Add(currentPoint);
            bool foundOne = true;
            //do while (foundOne)
            //    {
            foundOne = false;
            foreach (Location location in myBase)
            {
                //Up
                if (currentPoint.Row != 0 && int.Parse(file[currentPoint.Row - 1][currentPoint.Col].ToString()) != 9)
                {
                    myBase.Add(new Location(currentPoint.Row - 1, currentPoint.Col, int.Parse(file[currentPoint.Row - 1][currentPoint.Col].ToString())));
                    foundOne = true;
                }

                //Down
                if (currentPoint.Row != file.Length - 1 && int.Parse(file[currentPoint.Row + 1][currentPoint.Col].ToString()) != 9)
                {
                    myBase.Add(new Location(currentPoint.Row + 1, currentPoint.Col, int.Parse(file[currentPoint.Row + 1][currentPoint.Col].ToString())));
                    foundOne = true;
                }

                //Left
                if (currentPoint.Col != 0 && int.Parse(file[currentPoint.Row][currentPoint.Col - 1].ToString()) != 9)
                {
                    myBase.Add(new Location(currentPoint.Row, currentPoint.Col - 1, int.Parse(file[currentPoint.Row][currentPoint.Col - 1].ToString())));
                    foundOne = true;
                }
                //Right
                if (currentPoint.Col != file[0].Length - 1 && int.Parse(file[currentPoint.Row][currentPoint.Col + 1].ToString()) != 9)
                {
                    myBase.Add(new Location(currentPoint.Row, currentPoint.Col + 1, int.Parse(file[currentPoint.Row][currentPoint.Col + 1].ToString())));
                    foundOne = true;
                }

            }
            // }
            return myBase;
        }

        private Basin mapBasinRecurs(Location currentPoint, Basin basin, string[] file)
        {
            if (basin.Contains(currentPoint)) { return basin; }
            basin.Add(currentPoint);

            //Up
            if (currentPoint.Row != 0 && int.Parse(file[currentPoint.Row - 1][currentPoint.Col].ToString()) != 9)
            {
                basin = mapBasinRecurs(new Location(currentPoint.Row - 1, currentPoint.Col, int.Parse(file[currentPoint.Row - 1][currentPoint.Col].ToString())), basin, file);
            }

            //Down
            if (currentPoint.Row != file.Length - 1 && int.Parse(file[currentPoint.Row + 1][currentPoint.Col].ToString()) != 9)
            {
                basin = mapBasinRecurs(new Location(currentPoint.Row + 1, currentPoint.Col, int.Parse(file[currentPoint.Row + 1][currentPoint.Col].ToString())), basin, file);
            }

            //Left
            if (currentPoint.Col != 0 && int.Parse(file[currentPoint.Row][currentPoint.Col - 1].ToString()) != 9)
            {
                basin = mapBasinRecurs(new Location(currentPoint.Row, currentPoint.Col - 1, int.Parse(file[currentPoint.Row][currentPoint.Col - 1].ToString())), basin, file);
            }
            //Right
            if (currentPoint.Col != file[0].Length - 1 && int.Parse(file[currentPoint.Row][currentPoint.Col + 1].ToString()) != 9)
            {
                basin = mapBasinRecurs(new Location(currentPoint.Row, currentPoint.Col + 1, int.Parse(file[currentPoint.Row][currentPoint.Col + 1].ToString())), basin, file);
            }

            return basin;
        }
    }

    class Location : IEquatable<Location>
    {
        public Location(int row, int col, int value) 
        {
            Row = row;
            Col = col;
            Value = value;
        }

        public int Row { get; private set; }
        public int Col { get; private set; }
        public int Value { get; private set; }

    public bool Equals(Location other)
    {
        return this.Row == other.Row && this.Col == other.Col;
    }
    public override int GetHashCode() => (Row, Col).GetHashCode();
}

class Basin : List<Location>
{
    public int Size => this.Count;

}


}