using Kerstpuzzel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    [TestFixture]
    public class LanternFish
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public void CalculatePopulationTest()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D6P1E.txt").First().Split(',').Select(Int32.Parse).ToList();
            Assert.AreEqual(26, CalculatePopulation(population, 18));
            Assert.AreEqual(5934, CalculatePopulation(population, 80));
        }

        [Test]
        public void CalculatePopulationP2()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D6P1.txt").First().Split(',').Select(Int32.Parse).ToList();
           // Assert.AreEqual(365131, CalculatePopulation(population, 80));
            Assert.AreEqual(365131, CalculatePopulation(population, 256));
        }

        [Test]
        public void SecondAttemt()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D6P1E.txt").First().Split(',').Select(Int32.Parse).ToList();
            Int64 countall = 0;
            foreach (int fish in population)
            {
                countall += CalculateBigPopulation(new List<int>() { fish }, 256);
            }

            Assert.AreEqual(26984457539, countall);
        }

        public int CalculateBigPopulation(List<int> population, int days)
        {
            List<int> newPop = population.ToList();
           
            for (int i = 0; i < days; i++)
            {
                newPop = TomorrowsPopulation(newPop);  
            }
            return newPop.Count();
        }

        public int CalculatePopulation(List<int> population, int days)
        {
            List<int> newPopulation = population.ToList<int>();
            BestandHelper.SaveObject<List<int>>(newPopulation, @"newPop0" );

            for (int i = 0; i < days; i++)
            {
                newPopulation = BestandHelper.LoadObject<List<int>>("newPop" + i);
                newPopulation = TomorrowsPopulation(newPopulation.ToList<int>());
                BestandHelper.SaveObject<List<int>>(newPopulation, @"newPop" + (i+1));

                newPopulation = null;
            }

            newPopulation = BestandHelper.LoadObject<List<int>>(@"newPop" + (days));
            return newPopulation.Count;
        }

        public List<int> TomorrowsPopulation(List<int> population)
        {
            List<int> newfish = new List<int>();

            int countThe8 = population.Count(x => x == 0);
            foreach (int fish in population)
            {
                int fishIndex = fish - 1;
                newfish.Add(fishIndex < 0 ? 6 : fishIndex);
            }
            for (int j = 0; j < countThe8; j++)
            {
                newfish.Add(8);
            }

            return newfish;
        }
    }
}
