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
    public class _7DigitDisplay
    {
        
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test]
        public void Day2_Puz1E()
        {
            List<string> file = BestandHelper.Readfile(@"Input\D8P1.txt").ToList();

            List<string[]> solutions = new List<string[]>();

            //gea agfcbe egcbfd aecb cegbf cafgde fgeba ea gabdf begfdca | bcfeg ea fbdga fbgcdae
            foreach (string line in file)
            {
                string[] lineSplit = line.Split('|');
                string[] patterns = lineSplit[0].Trim().Split(' ');
                string[] output = lineSplit[1].Trim().Split(' ');

                string[] solution = new string[4];
                for (int i = 0; i < output.Count() ; i++)
                {
                    solution[i] = solveCode(output[i], patterns);
                }
                solutions.Add(solution);
            }

            int number =0 ;
            foreach (string[] sol in solutions)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(sol[0] ?? " ");
                sb.Append(sol[1] ?? " ");
                sb.Append(sol[2] ?? " ");
                sb.Append(sol[3] ?? " ");

                number += Int32.Parse(sb.ToString());

                Console.WriteLine(sb.ToString());

            }
            Console.WriteLine(number);
            Assert.AreEqual(1043101, number);         
        }
        
        private string solveCode(string code, string[] patterns)
        {
            switch (code.Length)
            {
                case 2: return "1";
                case 3: return "7";
                case 5: return Solve5(code, patterns); //2,3 of 5
                case 6: return Solve6(code, patterns); //0, 6 of 9
                case 4: return "4";
                case 7: return "8";
            }
            return "";
        }
        private string Solve5 (string code, string[] patterns)
        {
            //Can be 2,3 or 5
            string one = patterns.First(x => x.Length == 2);
            //if the 1 pattern is on, then this is a 3
            if(code.Contains(one[0]) && code.Contains(one[1]))
            {
                return "3";
            }

            //Only 2 and 5 to determine
            string four = patterns.First(x => x.Length == 4);
            if (code.Replace(four[0].ToString(), "").Replace(four[1].ToString(), "").Replace(four[2].ToString(), "").Replace(four[3].ToString(), "").Length == 2)
            {
                return "5";
            }

            return "2";
        }

        private string Solve6(string code, string [] patterns)
        {
            //Can be 0, 6 or 9
            string one = patterns.First(x => x.Length == 2);
            //if the 1 pattern is on, then this is a 3
            if (!(code.Contains(one[0]) && code.Contains(one[1])))
            {
                return "6";
            }

            string four = patterns.First(x => x.Length == 4);
            if (code.Replace(four[0].ToString(), "").Replace(four[1].ToString(), "").Replace(four[2].ToString(), "").Replace(four[3].ToString(), "").Length == 2)
            {
                return "9";
            }

            return "0";
        }
    }
}
