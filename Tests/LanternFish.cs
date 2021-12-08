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
            Assert.AreEqual(26, CalculatePopulation(population, 18, "newPop"));
            Assert.AreEqual(5934, CalculatePopulation(population, 80, "newPop"));
        }

        [Test]
        public void CalculatePopulationP2()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D6P1.txt").First().Split(',').Select(Int32.Parse).ToList();
           // Assert.AreEqual(365131, CalculatePopulation(population, 80));
            Assert.AreEqual(365131, CalculatePopulation(population, 256, "newPop"));
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

        [Test]
        public void ThirdAttemtp()
        {
            //Tot dag 155 gebruteforced
            List<int> newPopulation = BestandHelper.Readfile(@"Input\D6P1.txt").First().Split(',').Select(Int32.Parse).ToList();


            Console.WriteLine(newPopulation.Count(x => x == 0));
            Console.WriteLine(newPopulation.Count(x => x == 1));
            Console.WriteLine(newPopulation.Count(x => x == 2));
            Console.WriteLine(newPopulation.Count(x => x == 3));
            Console.WriteLine(newPopulation.Count(x => x == 4));
            Console.WriteLine(newPopulation.Count(x => x == 5));
            Console.WriteLine(newPopulation.Count(x => x == 6));
            Console.WriteLine(newPopulation.Count(x => x == 7));
            Console.WriteLine(newPopulation.Count(x => x == 8));
        }

        [Test]
        public void ThirdAttemtpCalcFirst20Days()
        {
            List<int> population = BestandHelper.Readfile(@"Input\D6P1E.txt").First().Split(',').Select(Int32.Parse).ToList();
            Int64 countall = 0;
            foreach (int fish in population)
            {
                countall += CalculatePopulation(new List<int>() { fish }, 20, "Example");
            }
        }

            [Test]
        public void ThirdAttemtpCalc()
        {
            //Fishes on day 20
            // int[] nextDay =new int[] { 2, 0, 1, 0, 0, 1, 0, 3, 0, 3 };
            int[] nextDay = new int[] { 0, 2, 0, 1, 0, 0, 1, 0, 3, 0 };

            for (int i = 20; i <= 256; i++)
            {
                nextDay = getNextDat(nextDay);
                i++;
            }            
            Console.WriteLine(nextDay.Sum());

            //  Assert.AreEqual(67116600, nextDay.Sum());
            //257358
        }

        private int[] getNextDat(int[] previousDay)
        {
            int offset = (previousDay[1] - previousDay[0]) + (previousDay[3] - previousDay[2]);
            int newVal = previousDay[previousDay.Length-1] + offset;
            return new int[] { previousDay[1], previousDay[2], previousDay[3], previousDay[4], previousDay[5], previousDay[6], previousDay[7], previousDay[8], previousDay[9], newVal };
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

        public int CalculatePopulation(List<int> population, int days, string fileName)
        {
            List<int> newPopulation = population.ToList<int>();
            BestandHelper.SaveObject<List<int>>(newPopulation, fileName + "0" );

            for (int i = 0; i < days; i++)
            {
                newPopulation = BestandHelper.LoadObject<List<int>>(fileName + i);
                newPopulation = TomorrowsPopulation(newPopulation.ToList<int>());
                BestandHelper.SaveObject<List<int>>(newPopulation, fileName + (i+1));

                newPopulation = null;
            }

            newPopulation = BestandHelper.LoadObject<List<int>>(fileName + (days));
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
