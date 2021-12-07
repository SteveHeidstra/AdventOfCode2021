using Kerstpuzzel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    [TestFixture]
    public class CrabSub
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public void CalculatePopulationTest()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D7P1E.txt").First().Split(',').Select(Int32.Parse).ToList();
            List<int> positions = population.Distinct().ToList();
            Dictionary<int, int> counters = new Dictionary<int, int>();

            foreach (int pos in positions)
            {
                counters.Add(pos, population.Count(x => x == pos));
            }

            int minfuel = int.MaxValue;
            int minpos = int.MinValue;

            foreach(int pos in positions)
            {
                int fuel = counters.Sum((item) => Math.Abs(item.Key - pos) * item.Value);
                
                if(fuel < minfuel)
                {
                    minfuel = fuel;
                    minpos = pos;
                }
            }

            Assert.AreEqual(37, minfuel);
            Assert.AreEqual(2, minpos);
        }

        [Test]
        public void Day7Puz1()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D7P1.txt").First().Split(',').Select(Int32.Parse).ToList();
            List<int> positions = population.Distinct().ToList();
            Dictionary<int, int> counters = new Dictionary<int, int>();

            foreach (int pos in positions)
            {
                counters.Add(pos, population.Count(x => x == pos));
            }

            int minfuel = int.MaxValue;
            int minpos = int.MinValue;

            foreach (int pos in positions)
            {
                int fuel = counters.Sum((item) => Math.Abs(item.Key - pos) * item.Value);

                if (fuel < minfuel)
                {
                    minfuel = fuel;
                    minpos = pos;
                }
            }

            Assert.AreEqual(341534, minfuel);
            Assert.AreEqual(363, minpos);
        }

        [Test]
        public void Day7Puz2E()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D7P1E.txt").First().Split(',').Select(Int32.Parse).ToList();
            List<int> positions = population.Distinct().ToList();
            Dictionary<int, int> counters = new Dictionary<int, int>();
            
            foreach (int pos in positions)
            {
                counters.Add(pos, population.Count(x => x == pos));
            }

            Int64 minfuel = int.MaxValue;
            int minpos = int.MinValue;

            for (int pos = 0; pos < positions.Max(); pos++)
            {
                Int64 fuel = counters.Sum((item) => (Math.Abs(item.Key - pos) * (Math.Abs(item.Key - pos) + 1)/2) * item.Value);
                
                if (fuel < minfuel)
                {
                    minfuel = fuel;
                    minpos = pos;
                }
            }

            Assert.AreEqual(168, minfuel);
            Assert.AreEqual(5, minpos);
        }

        [Test]
        public void Day7Puz2()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D7P1.txt").First().Split(',').Select(Int32.Parse).ToList();
            List<int> positions = population.Distinct().ToList();
            Dictionary<int, int> counters = new Dictionary<int, int>();

            foreach (int pos in positions)
            {
                counters.Add(pos, population.Count(x => x == pos));
            }

            Int64 minfuel = int.MaxValue;
            int minpos = int.MinValue;

            for (int pos = 0; pos < positions.Max(); pos++)
            {
                Int64 fuel = counters.Sum((item) => (Math.Abs(item.Key - pos) * (Math.Abs(item.Key - pos) + 1) / 2) * item.Value);

                if (fuel < minfuel)
                {
                    minfuel = fuel;
                    minpos = pos;
                }
            }

            Assert.AreEqual(93397632, minfuel);
            Assert.AreEqual(484, minpos);
        }

    }
}
