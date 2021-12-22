using Kerstpuzzel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace AoC2021.Day_11
{
    [TestFixture]
    class Cave
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public void StartTheSimulation()
        {
            CreateCave();
            for (int i = 1; i < 10; i++)
            {
                foreach (Octopus octopus in octopusses)
                {
                    octopus.ProcessStep(i);
                }
            }
            Assert.AreEqual(204, flashes);
        }

        List<Octopus> octopusses = new List<Octopus>();

        public void CreateCave()
        {
            string[] file = BestandHelper.Readfile(@"Input\D11P1E1.txt");
            for (int iRow = 0; iRow < file.Length; iRow++)
            {
                for (int iCol = 0; iCol < file[0].Length; iCol++)
                {
                    octopusses.Add(new Octopus(iRow, iCol, int.Parse(file[iRow][iCol].ToString())));
                }
            }

            foreach (Octopus octopus in octopusses)
            {
                List<Octopus> Neighbours = octopusses.Where(x =>
                        Math.Abs(x.Location.Row - octopus.Location.Row) <= 1 &&
                        Math.Abs(x.Location.Col - octopus.Location.Col) <= 1 &&
                        x.Location != octopus.Location).ToList();


                octopus.RegisterNeighbours(Neighbours);
                octopus.Flash += CountFlashes;
            }
        }

        int flashes;
        public void CountFlashes(object sender, OctoEventArgs e)
        {
            flashes++;
        }
    }


}
