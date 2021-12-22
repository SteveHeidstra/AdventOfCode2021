using Kerstpuzzel;
using Kerstpuzzel.Route;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{

    [TestFixture]
    class Day_22__cubes
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        HashSet<Cube> cubes = new HashSet<Cube>();

        [Test]
        public void SolvePuz1()
        {
            string[] testFile = BestandHelper.Readfile(@"Input\D22P1.txt");
            IEnumerable<string> file = testFile.Reverse();

            buildCubes();
    
            foreach (string line in file)
            {
                //on x=10..12,y=10..12,z=10..12
                string[] interpret = line.Split(' ');
                //x=10..12
                string[] coords = interpret[1].Split(',');
                int[] xCoord = GetCoords(coords, 'x');
                int[] yCoord = GetCoords(coords, 'y');
                int[] zCoord = GetCoords(coords, 'z');

                checkCubes(xCoord, yCoord, zCoord, interpret[0] == "on");
                if(!cubes.Any(x => x.Visited == false))
                {
                    break;
                }
                // runCuboid(xCoord, yCoord, zCoord, interpret[0] == "on");
                // Console.WriteLine(line);
            }

            Assert.AreEqual(547648, cubes.Count(c => c.On));
        }

        private void checkCubes(int[] xRange, int[] yRange, int[] zRange, bool on)
        {
            foreach (Cube cube in cubes.Where(x=> x.Visited == false))
            {
                if(cube.X >= xRange[0] && cube.X <= xRange[1] &&
                   cube.Y >= yRange[0] && cube.Y <= yRange[1] &&
                   cube.Z >= zRange[0] && cube.Z <= zRange[1] )
                {
                    cube.On = on;
                    cube.Visited = true;
                }
            }
        }

        private void buildCubes()
        {
            for (int x = -50; x <= 50; x++)
            {

                for (int y = -50; y <= 50; y++)
                {

                    for (int z = -50; z <= 50; z++)
                    {
                        cubes.Add(new Cube() { X = x, Y = y, Z = z, Visited = false, On =false });
                    }

                }
            }
        }


        private int[] GetCoords(string[] coords, char coordType)
        {
            string xString = coords.First(x => x[0] == coordType);
            string first = xString.Substring(2, xString.IndexOf('.')).Replace('.', ' ').Trim();
            string second = xString.Substring(xString.IndexOf('.')).Replace('.', ' ').Trim();

            int[] retVal = new int[] { int.Parse(first), int.Parse(second) };

            retVal[0] = Math.Max(retVal[0], -50);
            retVal[1] = Math.Min(retVal[1], 50);

            return retVal;
        }

        private void runCuboid(int[] xRange, int[] yRange, int[] zRange, bool on)
        {

            for (int x = xRange[0]; x <= xRange[1]; x++)
            {

                for (int y = yRange[0]; y <= yRange[1]; y++)
                {

                    for (int z = zRange[0]; z <= zRange[1]; z++)
                    {

                        Cube cube = cubes.FirstOrDefault<Cube>(c => c.X == x && c.Y == y && c.Z == z);
                        if (cube == null)
                        {
                            cube = new Cube() { X = x, Y = y, Z = z };
                            cubes.Add(cube);
                        }
                        cube.On = on;
                    }
                }
            }
        }

    }



    public class Cube : IEquatable<Cube>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public bool On { get; set; }
        public bool Visited { get; set; }


        public bool Equals(Cube other)
        {
            return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
        }
        public override int GetHashCode() => (X, Y, Z).GetHashCode();
    }

}
