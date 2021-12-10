using Kerstpuzzel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace AoC2021
{
    [TestFixture]
    class Day_10__Chuncks
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        Dictionary<string, string> pairs = new Dictionary<string, string>()
            {
                { "{", "}"},
                 {"[", "]"},
                  { "<", ">"},
                   { "(", ")"},

            };
        Dictionary<string, int> scores = new Dictionary<string, int>()
            {
                { ")", 3},
                 {"]", 57},
                  { "}",1197},
                   { ">",25137},

            };

        [Test]
        public void FindTheBugScore()
        {
            string[] file = BestandHelper.Readfile(@"Input\D10P1.txt");
            int score = 0;
            List<string> completers = new List<string>();
           

            foreach (string line in file)
            {
                string parseit = "";
                bool incomplete = true;

                for (int i = 0; i < line.Length; i++)
                {
                    string character = line[i].ToString();
                    
                    //It is a "starting char"
                    if (pairs.ContainsKey(character))
                    {
                        parseit += character;
                    }
                    //It is a "closing character"
                    else
                    {   //If the closing character does not match the last opening character we have a corrupted line 
                        if(character != pairs[parseit[parseit.Length - 1].ToString()])
                        {
                            //Lets count the score!!
                            score += scores[character];
                            incomplete = false;
                            parseit = parseit.Substring(0, parseit.Length - 1);
                            break;
                        }
                        //otherwise this may be an incomplete line, ,or a perfect line so keep going
                        else
                        {
                            parseit = parseit.Substring(0, parseit.Length - 1);
                        }
                    }
                }
                if (incomplete)
                {
                    completers.Add(parseit);
                }
            }

           // Console.WriteLine("CorruptedLinesScore: " + score);
            //Assert.AreEqual(26397, score);
            List<BigInteger> completerScores = new List<BigInteger>();
            foreach (string line in completers)
            {
                //Console.WriteLine(line);
                BigInteger completerScore = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    string endchar = pairs[line[line.Length - 1-i].ToString()];
                    completerScore = (completerScore * 5) + compScore[endchar];
                }

               // Console.WriteLine("CompletedLines: " + completerScore);
                completerScores.Add(completerScore);
            }

            completerScores.Sort();
            Console.WriteLine(completerScores[(int)Math.Floor(completerScores.Count/2.0)]);
           // Assert.Greater(completerScores[(int)Math.Floor(completerScores.Count / 2.0)], 189402312);

        }

        Dictionary<string, int> compScore = new Dictionary<string, int>()
            {
                { ")", 1},
                 {"]", 2},
                  { "}",3},
                   { ">",4},

            };
    }
}
