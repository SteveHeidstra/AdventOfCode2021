using Kerstpuzzel;
using Kerstpuzzel.Bingo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AoC2021
{
    [TestFixture]
    public class Bingo
    {
        [SetUp]
        public void Setup()
        {
            BestandHelper.ApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] file = BestandHelper.Readfile(@"Input\D4P1.txt");

           
            Boards = new List<Board>();
            bool first = true;
            Board currentBoard = null;
            int iRow = 0;

            foreach (string line in file)
            {
                 //1st line is bingo numbers
                if (first)
                {
                    bingonummers = Array.ConvertAll(file.First<string>().Split(','), s => int.Parse(s));

                    first = false;
                    continue;
                }   

                //On an empty line a new bingocard begins
                if (string.IsNullOrEmpty(line))
                {
                    //nieuw blok maken
                    if(currentBoard != null)
                    {
                        Boards.Add(currentBoard);
                    }
                    currentBoard = new Board();
                    iRow = 0;
                    continue;
                }

                string saneline = Regex.Replace(line, @"\s+", " ").Trim();

                currentBoard.SetGridRow(saneline.Split(' '), iRow);
                iRow++;
            }
            Boards.Add(currentBoard);
        }

        private int[] bingonummers;
        List<Board> Boards;

        [Test]
        public void PlayBingo()
        {
            foreach (int nummer in bingonummers)
            {
                foreach (Board board in Boards)
                {
                    if (board.MarkNumber(nummer))
                    {
                        if (board.CheckForBingo())
                        {
                            //Hier hebben we een winnende kaart!
                            Console.WriteLine(board.ToString());
                            Console.WriteLine(board.AoCBoardScore() * nummer);
                            Assert.True(true);
                            return;                          
                            ;
                        };
                    };
                }
            }
        }

        [Test]
        public void Lose_to_stupid_squid()
        {
            List<Board> findlast =new List<Board>();
            foreach (Board item in Boards)
            {
                findlast.Add(item);
            }

            foreach (int nummer in bingonummers)
            {
                foreach (Board board in Boards)
                {
                    if (board.MarkNumber(nummer))
                    {
                        if (board.CheckForBingo())
                        {
                            findlast.Remove(board);
                            if(findlast.Count() == 1 && findlast[0].CheckForBingo())
                            {
                               Console.WriteLine(board.ToString());
                                Console.WriteLine(nummer * board.AoCBoardScore());
                                Assert.AreEqual(14877, nummer * board.AoCBoardScore());
                                return;
                            }                                                      
                        };
                    };
                }
            }

            
        }
    }
}
