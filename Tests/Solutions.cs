using NUnit.Framework;
using Kerstpuzzel;
using System.IO;
using System.Reflection;
using System;

namespace Tests
{
    public class Solutions
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        #region Solved
        [Test]
        public void Day2_Puz1E()
        {
            string[] file = BestandHelper.Readfile(@"Input\D2P1E.txt");
            Submarine sub = new Submarine();

            foreach (string line in file)
            {
                Console.WriteLine(line);
                sub.Command = line;
                Console.WriteLine(sub.HorizontalPosition);
                Console.WriteLine(sub.Depth);

            }

            Assert.AreEqual(15, sub.HorizontalPosition);
            Assert.AreEqual(60, sub.Depth);
        }

        [Test]
        public void Day2_Puz1()
        {
            string[] file = BestandHelper.Readfile(@"Input\D2P1.txt");
            Submarine sub = new Submarine();

            foreach (string line in file)
            {
                sub.Command = line;
                Console.WriteLine(line);
            }

            Console.WriteLine(sub.HorizontalPosition);
            Console.WriteLine(sub.Depth);
            Console.WriteLine(sub.HorizontalPosition * sub.Depth);
        }

        [Test]
        public void Day2_Puz2()
        {
            string[] file = BestandHelper.Readfile(@"Input\D2P1.txt");
            Submarine sub = new Submarine();

            foreach (string line in file)
            {
                sub.Command = line;
                // Console.WriteLine(line);
            }

            Console.WriteLine(sub.HorizontalPosition);
            Console.WriteLine(sub.Depth);
            Console.WriteLine(sub.HorizontalPosition * sub.Depth);

        }

        [Test]
        public void Day3_Puz1E()
        { Submarine sub = new Submarine();

            sub.DiagnosticReport = BestandHelper.Readfile(@"Input\D3P1E.txt"); 

            Assert.AreEqual(198, sub.PowerConsumption);
        }

        [Test]
        public void Day3_Puz1()
        {
            Submarine sub = new Submarine();

            sub.DiagnosticReport = BestandHelper.Readfile(@"Input\D3P1.txt");
            
            Assert.AreEqual(2967914, sub.PowerConsumption);
        }

        #endregion

        [Test]
        public void Day3_Puz2E_Oxygen()
        {
            Submarine sub = new Submarine();

           sub.DiagnosticReport = BestandHelper.Readfile(@"Input\D3P1E.txt");

            Assert.AreEqual(23, sub.OxygenGeneratorRating);
             Assert.AreEqual(10, sub.CO2ScrubberRating);
            Assert.AreEqual(230, sub.LifeSupportRating);
        }

        [Test]
        public void Day3_Puz2()
        {
            Submarine sub = new Submarine();

            sub.DiagnosticReport = BestandHelper.Readfile(@"Input\D3P1.txt");

            Assert.AreEqual(7041258, sub.LifeSupportRating);
        }

    }
}