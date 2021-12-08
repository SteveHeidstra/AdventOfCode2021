using Kerstpuzzel;
using Kerstpuzzel.Bingo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace KerstpuzzelTests.Bingo
{
    [TestFixture]
    public class BingoTests
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
                    bingonummers = Array.ConvertAll(file.First().Split(','), s => int.Parse(s));

                    first = false;
                    continue;
                }

                //On an empty line a new bingocard begins
                if (string.IsNullOrEmpty(line))
                {
                    //nieuw blok maken
                    if (currentBoard != null)
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
                            Assert.True(true);
                            return;
                            ;
                        };
                    };
                }
            }
        }
    }
}
